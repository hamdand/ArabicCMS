<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AML.UI.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .form-control {
            height: calc(2.25rem + 8px);
        }
    </style>
    <section id="contact" class="section-bg wow fadeInUp text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="تسجيل الدخول"></asp:Literal></h3>
            </div>
            <div class="form-row">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <div class="form-group col-md-12">
                    <h6>
                        <asp:Literal runat="server" ID="litArName" Text="البريد الإلكتروني"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
                <div class="form-group col-md-12">
                    <h6>
                        <asp:Literal runat="server" ID="Literal1" Text="كلمة المرور"></asp:Literal></h6>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
                <div class="form-group col-md-12">
                    <asp:Button runat="server" OnClick="LogIn" Text="تسجيل الدخول" CssClass="border-0 btn-dark form-control" />
                </div>
                <div class="form-group col-10">
                    <div class="checkbox">
                        <asp:CheckBox runat="server" ID="RememberMe" />
                        <asp:Label runat="server" AssociatedControlID="RememberMe" Text="تذكرني"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-10">
                    <div class="checkbox">
                        <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" Text="تسجيل مستخدم جديد"></asp:HyperLink>
                    </div>
                </div>
                <div class="form-group col-10">
                    <div class="checkbox">
                        <asp:HyperLink runat="server" NavigateUrl="~/Account/Forgot.aspx" ID="lnkForgot" ViewStateMode="Disabled" Text="نسيت كلمة المرور؟"></asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="text-center">
            </div>

        </div>
    </section>

    <div class="col-md-4">
        <section id="socialLoginForm">
            <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" Visible="false" />
        </section>
    </div>
</asp:Content>
