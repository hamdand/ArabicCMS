<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AML.UI.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .form-control {
            height: calc(2.25rem + 8px);
        }
    </style>
    <%--<h2><%: Title %>.</h2>--%>

    <%--<div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
            </div>
        </div>
    </div>--%>


    <section id="contact" class="section-bg wow fadeInUp text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="تسجيل مستخدم جديد"></asp:Literal></h3>
            </div>
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="litArName" Text="البريد الإلكتروني"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" required />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ValidationGroup="submit" SetFocusOnError="true"
                        CssClass="text-danger" ErrorMessage="البريد الإلكتروني حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal1" Text="إسم الجهة"></asp:Literal></h6>
                    <%--<asp:TextBox runat="server" ID="txtEntityName" CssClass="form-control" />--%>
                    <asp:DropDownList ID="ddlEntityName" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEntityName" InitialValue="-1" ValidationGroup="submit"
                        CssClass="text-danger" ErrorMessage="إسم الجهة حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal2" Text="الإسم الأول"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtFName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName" ValidationGroup="submit"
                        CssClass="text-danger" ErrorMessage="الإسم الأول حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal4" Text="الإسم الأخير"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName" ValidationGroup="submit"
                        CssClass="text-danger" ErrorMessage="الإسم الأخير حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal6" Text="المسمى الوظيفي"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtJobTitle" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName" ValidationGroup="submit"
                        CssClass="text-danger" ErrorMessage="المسمى الوظيفي حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal7" Text="رقم الهاتف"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="txtMobile" TextMode="Phone" CssClass="form-control" required />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName" ValidationGroup="submit"
                        CssClass="text-danger" ErrorMessage="رقم الهاتف حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal5" Text="كلمة المرور"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ValidationGroup="submit"
                        CssClass="text-danger" ErrorMessage="كلمة المرور حقل إلزامي." />
                </div>
                <div class="form-group col-md-6">
                    <h6>
                        <asp:Literal runat="server" ID="Literal3" Text="إعادة كلمة المرور"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="كلمة المرور حقل إلزامي." ValidationGroup="submit" />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="يرجى إعادة كلمة المرور" ValidationGroup="submit" />
                </div>
            </div>
            <div class="text-center">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="تسجيل" CssClass="border-0 btn-dark form-control" ValidationGroup="submit" />
            </div>

        </div>
    </section>
</asp:Content>
