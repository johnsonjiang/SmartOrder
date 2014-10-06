<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LineItemsControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.LineItemsControl" %>
<%@ Import Namespace="VE.SMS.Common" %>
<script src="../Scripts/jquery-1.8.3.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function openProduct() {
        var type = $("#ddlProjectAdd").val();
        if (type == "材料") {
            type = "P";
        }
        else if (type == "成品") {
            type = "EP";
        }
        else {
            return;
        }
        var url = "productform.aspx?viewtype=create&closeafter=1&type=" + type;
        var obj = new Object();
        obj.name = "test";
        obj.value = "1212";
        var returnValue = window.showModelessDialog(url, obj,'dialogWidth=1200px;dialogHeight=960px;resizable=yes');
        if (returnValue == "Ok") {
            //            if (window.location.href.toString().indexOf("#maodian") > 0)
            window.location.href = window.location.href;
            //            else
            //                window.location.href = window.location.href + "#maodian";
        }

    }
</script>
<div class="generaldiv">
<table class="listtable">
                <tr class="gridheader">
                    <td width="5%">
                        序号
                    </td>
                    <td width="8%">
                        项目
                    </td>
                    <td width="12%" align="center">
                        说明
                    </td>
                    <td width="12%" align="center">
                        名称
                    </td>
                    <%if (IsSpecColumnVisible)
                      {%>
                    <td width="10%" align="center">
                        规格
                    </td>
                    <%} %>
                    <td width="5%" align="center">
                        单位
                    </td>
                    <%if (IsPriceColumnVisible && (ACLUtility.IsAccessible(ACLConsts.ViewOrdUnitPirce) || Page.GetType().FullName.Contains("OrderForm")))
                      {%>
                    <td width="5%" align="center">
                        单价
                    </td>
                    <%} %>
                    <td width="5%" align="center">
                        数量
                    </td>
                    <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdXiaoji))
                      { %>
                    <td width="5%" align="center">
                        小计
                    </td>
                    <%} %>
                    <td width="15%" align="center">
                        备注
                    </td>
                    <%if (this.Page.GetType().FullName.Contains("settlement") || this.Page.GetType().FullName.Contains("Settlement"))
                      { %>
                    <td>
                        送货单号
                    </td>
                    <%} %>
                    <td width="8%" align="center">
                        操作
                    </td>
                </tr>
                <tr class="gridrowadd">
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProjectAdd" runat="server" CssClass="dropdownlist" Width="80%"
                            ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlProjectAdd_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtIntroAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlProductNameAdd" runat="server" Width="80%" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlProductNameAdd_SelectedIndexChanged">
                        </asp:DropDownList>
                        <a href='javascript:openProduct();' name="maodian" style="text-decoration: none"><font
                            size="4px">+</font></a>
                    </td>
                    <%if (IsSpecColumnVisible)
                      {%>
                    <td align="center">
                        <asp:TextBox ID="txtSpecAdd" runat="server" CssClass="text" Width="80%" Text="" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <%} %>
                    <td align="center">
                        <asp:DropDownList ID="ddlUnitAdd" runat="server" CssClass="dropdownlist" Width="98%"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlProductNameAdd_SelectedIndexChanged"
                            ClientIDMode="Static">
                        </asp:DropDownList>
                    </td>
                    <%if (IsPriceColumnVisible && (ACLUtility.IsAccessible(ACLConsts.ViewOrdUnitPirce) || Page.GetType().FullName.Contains("OrderForm")))
                      {%>
                    <td align="center">
                        <asp:TextBox ID="txtUnitPriceAdd" runat="server" CssClass="text" Width="70%" Text=""
                            ValidationGroup="Line" ClientIDMode="Static"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                            SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtUnitPriceAdd" Type="Double"
                            ValidationGroup="Line" Display="Dynamic"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                            ControlToValidate="txtUnitPriceAdd" SetFocusOnError="True" ValidationGroup="Line"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <%} %>
                    <td align="center">
                        <asp:TextBox ID="txtQtyAdd" runat="server" CssClass="text" Width="70%" Text="" ClientIDMode="Static"
                            ValidationGroup="Line"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
                            ControlToValidate="txtQtyAdd" Operator="DataTypeCheck" SetFocusOnError="True"
                            Type="Double" ValidationGroup="Line" Display="Dynamic"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="rqqty" runat="server" ErrorMessage="*" ForeColor="Red"
                            ControlToValidate="txtQtyAdd" SetFocusOnError="True" ValidationGroup="Line" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdXiaoji))
                      { %>
                    <td align="center">
                        <asp:Label ID="lblTotalAdd" runat="server" ClientIDMode="Static"></asp:Label>
                    </td>
                    <%} %>
                    <td align="center">
                        <asp:TextBox ID="txtRemarkAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                    </td>
                    <%if (this.Page.GetType().FullName.Contains("settlement") || this.Page.GetType().FullName.Contains("Settlement"))
                      { %>
                    <td>
                    </td>
                    <%} %>
                    <td align="center">
                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="button" Text="新增" CommandName="Add"
                            ValidationGroup="Line" onclick="btnAdd_Click"></asp:LinkButton>
                    </td>
                </tr>
    <asp:Repeater ID="rpItems" runat="server" OnItemCommand="rpItems_ItemCommand" OnItemDataBound="rpItems_ItemDataBound">
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <%#Container.ItemIndex +1 %>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("LineItem_Id") %>' />
                </td>
                <td>
                    <%#Eval("Project") %>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtIntro" runat="server" Text='<%#Eval("Intro") %>' CssClass="text"
                        Width="80%"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                </td>
                <%if (IsSpecColumnVisible)
                  {%>
                <td align="center">
                    <asp:TextBox ID="txtSpec" runat="server" Text='<%#Eval("Spec") %>' CssClass="text"
                        Width="80%"></asp:TextBox>
                </td>
                <%} %>
                <td align="center">
                   <asp:TextBox ID="txtUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:TextBox>
                </td>
                <%if (IsPriceColumnVisible && (ACLUtility.IsAccessible(ACLConsts.ViewOrdUnitPirce) || Page.GetType().FullName.Contains("OrderForm")))
                  {%>
                <td align="left">
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("UnitPrice") %>' CssClass="text"
                        Width="70%" ValidationGroup="LineItem"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                        SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtPrice" Type="Double"
                        ValidationGroup="LineItem" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                        ControlToValidate="txtPrice" SetFocusOnError="True" ValidationGroup="LineItem"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <%} %>
                <td align="left">
                    <asp:TextBox ID="txtQty" runat="server" Text='<%#Eval("Quantity")%>' CssClass="text"
                        Width="70%" ValidationGroup="LineItem"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                        SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtQty" Type="Double"
                        ValidationGroup="LineItem" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ForeColor="Red" ControlToValidate="txtQty" SetFocusOnError="True" ValidationGroup="LineItem"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdXiaoji))
                  { %>
                <td align="center">
                    <%# Convert.ToDouble(Eval("UnitPrice")) * Convert.ToDouble(Eval("Quantity")) %>
                </td>
                <%} %>
                <td align="center">
                    <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("Remark")%>' CssClass="text"
                        Width="80%"></asp:TextBox>
                </td>
                <%if (this.Page.GetType().FullName.Contains("settlement") || this.Page.GetType().FullName.Contains("Settlement"))
                  { %>
                <td>
                    <asp:Label ID="lblDelNo" runat="server"></asp:Label>
                </td>
                <%} %>
                <td align="center">
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save"
                        ValidationGroup="LineItem"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="刪除" CssClass="button" CommandName="Delete"
                        ValidationGroup="LineItem"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <%#Container.ItemIndex +1 %>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("LineItem_Id") %>' />
                </td>
                <td>
                    <%#Eval("Project") %>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtIntro" runat="server" Text='<%#Eval("Intro") %>' CssClass="text"
                        Width="80%"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                </td>
                <%if (IsSpecColumnVisible)
                  {%>
                <td align="center">
                    <asp:TextBox ID="txtSpec" runat="server" Text='<%#Eval("Spec") %>' CssClass="text"
                        Width="80%"></asp:TextBox>
                </td>
                <%} %>
                <td align="center">
                    <asp:TextBox ID="txtUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:TextBox>
                </td>
                <%if (IsPriceColumnVisible && (ACLUtility.IsAccessible(ACLConsts.ViewOrdUnitPirce) || Page.GetType().FullName.Contains("OrderForm")))
                  {%>
                <td align="left">
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("UnitPrice") %>' CssClass="text"
                        Width="70%" ValidationGroup="LineItem"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                        SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtPrice" Type="Double"
                        ValidationGroup="LineItem" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                        ControlToValidate="txtPrice" SetFocusOnError="True" ValidationGroup="LineItem"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <%} %>
                <td align="left">
                    <asp:TextBox ID="txtQty" runat="server" Text='<%#Eval("Quantity")%>' CssClass="text"
                        Width="70%" ValidationGroup="LineItem"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                        SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtQty" Type="Double"
                        ValidationGroup="LineItem" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ForeColor="Red" ControlToValidate="txtQty" SetFocusOnError="True" ValidationGroup="LineItem"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdXiaoji))
                  { %>
                <td align="center">
                    <%# Convert.ToDouble(Eval("UnitPrice")) * Convert.ToDouble(Eval("Quantity")) %>
                </td>
                <%} %>
                <td align="center">
                    <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("Remark")%>' CssClass="text"
                        Width="80%"></asp:TextBox>
                </td>
                <%if (this.Page.GetType().FullName.Contains("settlement") || this.Page.GetType().FullName.Contains("Settlement")){%>
                <td>
                    <asp:Label ID="lblDelNo" runat="server"></asp:Label>
                </td>
                <%} %>
                <td align="center">
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save"
                        ValidationGroup="LineItem"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="刪除" CssClass="button" CommandName="Delete"
                        ValidationGroup="LineItem"></asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
            <%if (IsFooterVisible)
              {%>
            <div style="float: right; padding-right: 25px">
                <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdHeji))
                  { %>
                <b>材料合计:</b><asp:Label ID="lblMaterialAmount" runat="server"></asp:Label>
                <b>加工合计:</b><asp:Label ID="lblMachAmount" runat="server"></asp:Label>
                <b>安装合计:</b><asp:Label ID="lblInstallAmount" runat="server"></asp:Label>
                <b>成品合计:</b><asp:Label ID="lblEndProductAmount" runat="server"></asp:Label>
                <%} %>
                <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdZongji))
                  { %>
                <b>总计:</b><asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                <%} %>
            </div>
            <%} %>
        </FooterTemplate>
    </asp:Repeater>
    <asp:LinkButton ID="btnFocus" runat="server"></asp:LinkButton>
</div>
