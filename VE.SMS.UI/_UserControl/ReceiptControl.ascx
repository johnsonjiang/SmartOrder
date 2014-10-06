<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiptControl.ascx.cs"
	Inherits="VE.SMS.UI._UserControl.ReceiptControl" %>
<script language="javascript" type="text/javascript">
	$(document).ready(function () {
		$("#txtReceiptDate").datepicker();
	});
</script>
<div class="generaldiv">
	<asp:Repeater ID="rpItems" runat="server" OnItemCommand="rpItems_ItemCommand" 
        onitemdatabound="rpItems_ItemDataBound">
		<HeaderTemplate>
			<table class="listtable">
				<tbody>
					<tr class="gridheader">
						<td>
							日期
						</td>
						<td>
							已收金额
						</td>
						<td>
							收款人员
						</td>
						<td>
							备注
						</td>
					</tr>
					<tr class="gridrowadd">
						<td>
							<asp:TextBox ID="txtReceiptDate" runat="server" CssClass="text" Width="80%" ClientIDMode="Static" ValidationGroup="Receipt"></asp:TextBox>
                            <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Receipt" ControlToValidate="txtReceiptDate" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
						</td>
						<td>
							<asp:TextBox ID="txtReceiptAmount" runat="server" CssClass="text" Width="80%" ValidationGroup="Receipt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" ControlToValidate="txtReceiptAmount" SetFocusOnError="True" ValidationGroup="Receipt"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"  Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtReceiptAmount" Type="Double"  ValidationGroup="Receipt"></asp:CompareValidator>
							<td>
								<asp:TextBox ID="txtReceiptMan" runat="server" CssClass="text" Width="80%" ValidationGroup="Receipt" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Receipt" ControlToValidate="txtReceiptMan" ></asp:RequiredFieldValidator>
							</td>
							<td>
								<asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="80%"></asp:TextBox>
								<asp:LinkButton ID="btnCreateFollowUp" runat="server" Text="新增" CssClass="button" ValidationGroup="Receipt" 
									CommandName="Add" />
							</td>
						</td>
					</tr>
		</HeaderTemplate>
		<ItemTemplate>
			<tr class="gridrow">
				<td>
					<%#Convert.ToDateTime(Eval("ReceivedDate")).ToString("yyyy-MM-dd")%>
				</td>
				<td>
					<%#Eval("ReceivedAmount")%>
				</td>
				<td>
					<%#Eval("Man")%>
				</td>
				<td>
					<%#Eval("Remark")%>
				</td>
			</tr>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<tr class="gridrowalt">
				<td>
					<%#Convert.ToDateTime(Eval("ReceivedDate")).ToString("yyyy-MM-dd")%>
				</td>
				<td>
					<%#Eval("ReceivedAmount")%>
				</td>
				<td>
					<%#Eval("Man")%>
				</td>
				<td>
					<%#Eval("Remark")%>
				</td>
			</tr>
		</AlternatingItemTemplate>
		<FooterTemplate>
                    <tr>
                <td colspan="9" align="right" style="font-weight:bolder">
                    总计金额：<asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                </td>
            </tr>
			</tbody></table>
		</FooterTemplate>
	</asp:Repeater>
    <asp:LinkButton ID="btnFocus" runat="server"></asp:LinkButton>
</div>
