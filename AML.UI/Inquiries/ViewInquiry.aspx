<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInquiry.aspx.cs" Inherits="AML.UI.Inquiries.ViewInquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="about" class="wow fadeInUp">
        <section>
            <div class="container">


                <div class="section-header">
                    <h3>
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal></h3>
                    <p>
                        <asp:Literal ID="litDes" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="form content-form">
                    <asp:Literal runat="server" ID="litSendMsg" Mode="PassThrough"></asp:Literal>

                    <asp:Literal runat="server" ID="litErrorMsg" Mode="PassThrough"></asp:Literal>
                    <div class="form-row">
                        <div class="form-group col-md-12 text-align-lang">
                            <asp:Literal runat="server" ID="litContent" Mode="PassThrough" Text="لا يوجد محتوى"></asp:Literal>
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </div>

</asp:Content>
