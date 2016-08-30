<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebApplication2._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Date and Time Validation Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;
                            <div style="display: inline-block; vertical-align: middle; width: 700px" id="Div4"
                    runat="server"><span style="display: inline-block; width: 662px"><asp:Label ID="LblIncidentDt" runat="server" Width="95px" Text="Date of Incident: "
                                Height="18px" Font-Size="12px" Font-Names="Arial" EnableViewState="False"></asp:Label>
                            <asp:TextBox ID="txtDOS" runat="server" Width="79px" Font-Size="12px" Font-Names="Arial"
                                ToolTip="Enter date in 12/31/2000 format. Only '/' or '.' or '-' allowed for separators."
                                AutoPostBack="True" Height="14px"></asp:TextBox>
                            <asp:Image ID="Image1" runat="server" EnableViewState="False" EnableTheming="False"
                                ImageUrl="../Images/Buttons/Custom/Calendar_scheduleHS.png"></asp:Image>
                            <asp:Label Style="vertical-align: middle" ID="lblDoi" runat="server" Visible="False"
                                Width="14px" Text="*" Height="1px" Font-Bold="True" ForeColor="Red" CssClass="validate"
                                Font-Italic="False"></asp:Label>
                            <asp:RequiredFieldValidator ID="rvldHasdate" runat="server" Text="*" CssClass="validate"
                                ValidationGroup="ValidationContinue" ErrorMessage="You Must Select a Date." ControlToValidate="txtDOS"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Text="!" CssClass="validate"
                                ValidationGroup="ValidationContinue" ToolTip="Cannot enter future dates." ErrorMessage="Cannot enter future dates."
                                ControlToValidate="txtDOS" Type="Date" Operator="LessThanEqual" ControlToCompare="txttdy"></asp:CompareValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" EnableViewState="False"
                                ErrorTooltipEnabled="false" AcceptAMPM="false" MaskType="Date" MessageValidatorTip="true"
                                Mask="99/99/9999" TargetControlID="txtDOS" Century="2000">
                            </ajaxToolkit:MaskedEditExtender>
                            <ajaxToolkit:CalendarExtender ID="CE2" runat="server" EnableViewState="false" TargetControlID="txtDOS"
                                Format="MM/dd/yyyy" PopupButtonID="Image1" PopupPosition="TopRight">
                            </ajaxToolkit:CalendarExtender>
                            <asp:Label ID="Label11" runat="server" Width="97px" Text="Time of Incident: " Height="18px"
                                Font-Size="12px" Font-Names="Arial" EnableViewState="False"></asp:Label>
                            <asp:TextBox ID="txtTOD" runat="server" Width="58px" Font-Size="12px" Font-Names="Arial"
                                ToolTip="Enter time as hh:mm only"></asp:TextBox>
                            <asp:Label Style="vertical-align: middle" ID="lbltod" runat="server" Visible="False"
                                Width="14px" Text="*" Height="1px" Font-Bold="True" ForeColor="Red" CssClass="validate"
                                ToolTip="Time is in error or is a future time." Font-Italic="False"></asp:Label>
                            <asp:RequiredFieldValidator ID="rvldtime" runat="server" Text="*" CssClass="validate"
                                ValidationGroup="ValidationContinue" ToolTip="You Must Select an Incident Type."
                                ErrorMessage="You Must Select a Time." ControlToValidate="txtTOD"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rvldTOD" runat="server" Visible="False" Text="!"
                                CssClass="validate" ValidationGroup="ValidateOther" ToolTip="Occurrence Time not in proper hh:mm military time format."
                                ErrorMessage="Occurrence Time not in proper hh:mm time format." ControlToValidate="txtTOD"
                                ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9])$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MEtime" runat="server" ErrorTooltipEnabled="false"
                                AcceptAMPM="True" MaskType="Time" MessageValidatorTip="true" Mask="99:99" TargetControlID="txtTOD"
                                Century="2000">
                            </ajaxToolkit:MaskedEditExtender>
                            <asp:TextBox ID="txttdytod" TabIndex="99" runat="server" Width="1px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ValidationGroup="ValidationTime"
                                AutoPostBack="True" ReadOnly="True" CausesValidation="True" BorderStyle="None"
                                BorderColor="#ECE9E0" BackColor="#ECE9E0"></asp:TextBox>
                            <asp:TextBox ID="txttemptod" TabIndex="99" runat="server" Width="1px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ValidationGroup="ValidationTime"
                                ToolTip="Enter time as military time  hh:mm only" AutoPostBack="True" ReadOnly="True"
                                CausesValidation="True" BorderStyle="None" BorderColor="#ECE9E0" BackColor="#ECE9E0"></asp:TextBox>
                            <asp:TextBox ID="txtIncidentID" TabIndex="99" runat="server" Width="25px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="true" ForeColor="#ECE9E0" AutoPostBack="True"
                                ReadOnly="True" CausesValidation="True" BorderStyle="None" BorderColor="#ECE9E0"
                                BackColor="#ECE9E0" BorderWidth="1px"></asp:TextBox>
                            <asp:TextBox ID="txtLogDateView" TabIndex="99" runat="server" Width="24px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ReadOnly="True"
                                CausesValidation="True" BorderStyle="None" BorderColor="#ECE9E0" BackColor="#ECE9E0"
                                BorderWidth="1px"></asp:TextBox>
                            <asp:TextBox ID="txtDOS2" TabIndex="99" runat="server" Width="26px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ToolTip="Enter time as military time  hh:mm only"
                                AutoPostBack="false" ReadOnly="True" BorderStyle="None" BorderColor="#ECE9E0"
                                BackColor="#ECE9E0"></asp:TextBox>
                            <asp:TextBox ID="txtDateTime" TabIndex="99" runat="server" Width="24px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ReadOnly="True"
                                CausesValidation="True" BorderStyle="None" BorderColor="#ECE9E0" BackColor="#ECE9E0"
                                BorderWidth="1px"></asp:TextBox>
                            <asp:TextBox ID="txtActionSteps" TabIndex="99" runat="server" Width="24px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ReadOnly="True"
                                CausesValidation="True" BorderStyle="None" BorderColor="#ECE9E0" BackColor="#ECE9E0"
                                BorderWidth="1px"></asp:TextBox>
                            <asp:TextBox ID="txttdy" TabIndex="99" runat="server" Width="1px" Font-Size="12px"
                                Font-Names="Arial" EnableViewState="False" ForeColor="#ECE9E0" ValidationGroup="ValidationTime"
                                ReadOnly="True" BorderStyle="None" BorderColor="#ECE9E0" BackColor="#ECE9E0"></asp:TextBox></span><span style="display: inline-block; width: 652px">
                                            <asp:Label Style="vertical-align: middle" ID="LblDocDate" runat="server" Width="181px"
                                                Text="Date and Time of Notification:" Height="19px" Font-Size="12px" Font-Names="Arial"
                                                EnableViewState="False"></asp:Label>
                                            <asp:TextBox ID="txtMgrNotifyDt" runat="server" Width="137px" Height="13px" Font-Size="12px"
                                                Font-Names="Arial" ReadOnly="True" BorderStyle="Solid" BorderColor="ControlDark"
                                                BackColor="#E0E0E0" BorderWidth="1px"></asp:TextBox>
                                        </span>
                </div>
    
    </div>
    </form>
</body>
</html>
