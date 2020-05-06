using System;
using System.Data;
using System.Windows.Forms;

namespace Assistant
{
    public partial class UcAddressChoice : UserControl
    {
        #region Inner elemets
        /// <summary>
        /// Params for UcAddressChoice control
        /// </summary>
        private class AddressChoiceParams
        {
            /// <summary>
            /// Stored procedure name
            /// </summary>
            public string ProcName { get; set; }
            /// <summary>
            /// Procedure parameters array
            /// </summary>
            public object[] ProcPars { get; set; }
            /// <summary>
            /// TreeNode tag property name
            /// </summary>
            public string NodeTagFieldName { get; set; }
            /// <summary>
            /// TreeNode name
            /// </summary>
            public string NodeNameField { get; set; }
        }
        #endregion
        #region Props&Fields
        private BaseFactory container;
        private DataTable source;
        private AddressResponse Address { get; set; }
        /// <summary>
        /// Oblast, City, Street, Building, Apartment
        /// </summary>
        private Action<object, object, object, object, object> addressAction;
        private Action<AddressResponse> addressMessage;
        /// <summary>
        /// Node group for search. 
        /// </summary>
        /// <remarks>1 - oblast, 2 - city, 3 - street</remarks>
        private int _Level { get; set; }
        /// <summary>
        /// Current street node which selected
        /// </summary>
        private TreeNode StreetNode { get; set; }
        #endregion
        #region Constructors
        private UcAddressChoice()
        {
            InitializeComponent();

            container = new BaseFactory(DbType.Test);
        }
        /// <summary>
        /// Oblast, City, Street, Building, Apartment
        /// </summary>
        public UcAddressChoice(Action<object, object, object, object, object> action)
            : this()
        {
            addressAction = action;           
        }
        public UcAddressChoice(Action<AddressResponse> action)
            : this()
        {
            addressMessage = action;
        }
        #endregion
        #region Service methods
        /// <summary>
        /// Universal method for tree filling
        /// </summary>
        /// <param name="node">Root node</param>
        /// <param name="param"></param>
        private DataTable Popup(TreeNode node, AddressChoiceParams param)
        {
            TreeNode newNode;
            DataRow row;
                        
            source = container.SelectToTableByParName(param.ProcName, param.ProcPars);

            for(int i = 0; i < source.Rows.Count; i++)
            {
                row = source.Rows[i];
                newNode = new TreeNode(row[param.NodeNameField].ToString())
                {
                    Tag = _Level == 3 ? row : row[param.NodeTagFieldName]
                };

                node.Nodes.Add(newNode);
            }

            node.Expand();

            return source;
        }
        /// <summary>
        /// Find object by name
        /// </summary>
        private void FindText(TreeNode treeNode, string searchText)
        {
            string nodeText;

            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Level == _Level)
                {
                    nodeText = tn.Text.ToLower();

                    if (nodeText.Contains(searchText.ToLower()))
                    {
                        treeViewAddress.SelectedNode = tn;                                              
                        break;
                    }
                }

                FindText(tn, searchText);
            }
        }
        /// <summary>
        /// Fire after oblast changed
        /// </summary>
        private void AfterOblastChanged(TreeNode curNode, ref AddressChoiceParams addrParams)
        {
            addrParams = new AddressChoiceParams
            {
                ProcName = "pack_city.find",
                ProcPars = new object[] { "p_ci_obl_id", curNode.Tag,
                                          "p_rownum", 1000 },
                NodeTagFieldName = "CI_ID",
                NodeNameField = "CI_NAME"
            };

            _Level = 2;
            beObjectName.Enabled = true;
            ClearFields();
        }
        /// <summary>
        /// Fire after city changed
        /// </summary>
        private void AfterCityChanged(TreeNode curNode, ref AddressChoiceParams addrParams)
        {
            addrParams = new AddressChoiceParams
            {
                ProcName = "pack_street.find_street",
                ProcPars = new object[] { "p_st_ci_id", curNode.Tag },                
                NodeNameField = "ST_NAME"
            };

            _Level = 3;
            ClearFields();
        }
        /// <summary>
        /// Initiallise drop-down list buid nums
        /// </summary>
        private void AfterStreetChanged(TreeNode streetNode)
        {
            DataRow streetRow = (DataRow)streetNode.Tag;
            string numsStr = streetRow["ST_NUMS"].ToString();

            char[] separators = { ' ', ',' };
            string[] numArr = numsStr?.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            leSubaddrBuildingNum.Properties.DataSource = numArr;
            StreetNode = streetNode;
            tbSubaddrApartmentNum.Text = string.Empty;
        }
        private void fillAddressMessage(TreeNode nd)
        {
            if(nd.Level > 0)
            {
                switch (nd.Level)
                {
                    case 1:
                        Address.OblastId = nd.Tag; 
                        break;
                    case 2:
                        Address.CityId = nd.Tag;
                        break;
                    case 3:
                        Address.StreetId = ((DataRow)nd.Tag)["ST_ID"];
                        break;
                }
                fillAddressMessage(nd.Parent);
            }
        }
        /// <summary>
        /// Clear numbers of building, apartment number
        /// </summary>
        private void ClearFields()
        {
            leSubaddrBuildingNum.Properties.DataSource = null;
            tbSubaddrApartmentNum.Text = string.Empty;
        }
        #endregion
        #region Events
        private void UcAdrressChoice_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = treeViewAddress.Nodes[0];

            AddressChoiceParams addrParsObl = new AddressChoiceParams
            {
                ProcName = "pack_oblast.sel_oblast",
                NodeTagFieldName = "OBL_ID",
                NodeNameField = "OBL_NAME"
            };

            Popup(rootNode, addrParsObl);
        }
        private void treeViewAddress_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            TreeNode curNode = e.Node;
            bool HasChild = curNode.Nodes.Count > 0 ? true : false;
            AddressChoiceParams addrPars = null;
            
            switch (curNode.Level)
            {
                //Pop cities
                case 1 when !HasChild:
                    AfterOblastChanged(curNode, ref addrPars);
                    break;
                //Pop streets
                case 2 when !HasChild:
                    AfterCityChanged(curNode, ref addrPars);
                    break;
                //Set datasource building numbers
                case 3:
                    AfterStreetChanged(curNode);
                    break;
                default:
                    _Level = 3;
                    break;
            }

            treeViewAddress.TopNode = treeViewAddress.SelectedNode;

            if (addrPars != null)
                Popup(curNode, addrPars);
        }
        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            Address.Appartment = tbSubaddrApartmentNum.Text;
            Address.Building = leSubaddrBuildingNum.EditValue;

            fillAddressMessage(StreetNode);

            if (addressMessage == null)
                addressAction(Address.OblastId, Address.CityId, Address.StreetId, Address.Building, Address.Appartment);               
            else
                addressMessage(Address);

            Dispose();
        }
        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void beObjectName_EditValueChanged(object sender, EventArgs e)
        {
            timerObjectNameChanged.Stop();
            timerObjectNameChanged.Start();
        }
        private void timerObjectNameChanged_Tick(object sender, EventArgs e)
        {
            timerObjectNameChanged.Enabled = false;
            FindText(treeViewAddress.Nodes[0], beObjectName.Text);
        }
        #endregion
    }
}
