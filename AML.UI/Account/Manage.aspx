<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="AML.UI.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .form-control {
            height: calc(2.25rem + 8px);
        }
    </style>


    <section id="contact" class="section-bg wow fadeInUp text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="تسجيل مستخدم جديد"></asp:Literal></h3>
                <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false" ViewStateMode="Disabled">
                    <p class="text-success" style="border: 1px solid rgb(40, 167, 69); vertical-align: central; padding-top: 30px;"><%: SuccessMessage %></p>
                </asp:PlaceHolder>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="litArName" Text="البريد الإلكتروني"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Enabled="false" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="البريد الإلكتروني حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal1" Text="إسم الجهة"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtEntityName" CssClass="form-control" Enabled="false" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEntityName"
                        CssClass="text-danger" ErrorMessage="إسم الجهة حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal2" Text="الإسم الأول"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtFName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName"
                        CssClass="text-danger" ErrorMessage="الإسم الأول حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal4" Text="الإسم الأخير"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName"
                        CssClass="text-danger" ErrorMessage="الإسم الأخير حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal3" Text="المسمى الوظيفي"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtJobTitle" CssClass="form-control" />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal5" Text="رقم الهاتف"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control" />
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnUpdate" runat="server" Text="تحديث" OnClick="Unnamed_Click" CssClass="border-0 btn-dark form-control" />
            </div>
            <div class="form-group col-md-6">
                <a href="ManagePassword">
                    <asp:Literal ID="litChangePsw" runat="server" Text="تغيير كلمة المرور"></asp:Literal></a>
            </div>
        </div>
    </section>


    <h2 style="display: none;"><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row" style="display: none;">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <%--       <dt>External Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>--%>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt style="display: none;">Two-Factor Authentication:</dt>
                    <dd style="display: none;">
                        <p>
                            There are no two-factor authentication providers configured. See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                            for details on setting up this ASP.NET application to support two-factor authentication.
                        </p>
                        <% if (TwoFactorEnabled)
                            { %>
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                            else
                            { %>
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
