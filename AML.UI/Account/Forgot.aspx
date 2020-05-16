<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="AML.UI.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="contact" class="section-bg wow fadeInUp text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="نسيت كلمة المرور"></asp:Literal></h3>
                <p>
                    <asp:Literal runat="server" ID="litForgot" Text="سيتم إرسال رابط إعادة ضبط إلى بريدك الإلكتروني"></asp:Literal></p>
            </div>
            <div class="form-row">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                    <p class="text-info">
                        <asp:Literal runat="server" ID="litConfirmed" Text="Please check your email to reset your password."></asp:Literal>
                    </p>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="Literal1" />
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
                    <asp:Button runat="server" Text="إرسال رابط إلى البريد الإلكتروني" OnClick="Forgot" CssClass="border-0 btn-dark form-control" />
                </div>
            </div>
            <div class="text-center">
            </div>

        </div>
    </section>

    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="form-horizontal">
                    <h4>Forgot your password?</h4>
                    <hr />

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Email Link" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

        </div>
    </div>
</asp:Content>
