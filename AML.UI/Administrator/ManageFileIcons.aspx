<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="ManageFileIcons.aspx.cs" Inherits="AML.UI.Administrator.ManageFileIcons" %>

<%@ Import Namespace="AML.Domain.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="about">

        <section id="contact" class="wow fadeInUp">
            <div class="container">

                <div class="section-header">
                    <h3>النوع الرئيسي</h3>
                    <p>النوع الرئيسي سوف يظهر في القائمة العليا</p>
                </div>
                <div class="form" style="direction: rtl; text-align: right;">
                    <asp:Literal runat="server" ID="litSendMsg" Mode="PassThrough"></asp:Literal>

                    <asp:Literal runat="server" ID="litErrorMsg" Mode="PassThrough"></asp:Literal>

                    <div style="direction: rtl;">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="litArName" Text="إمتداد الملف"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtArName" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal1" Text="صورة الملف"></asp:Literal></h6>
                                <asp:FileUpload ID="fuDocument" runat="server" CssClass="form-control border-info" required></asp:FileUpload>
                                <div class="validation"></div>
                            </div>
                        </div>
                    </div>
                    <div class="text-center">
                        <asp:Button Text="حفظ" runat="server" ID="btnSave" OnClick="btnSave_Click" CssClass="border-0 btn-dark form-control" />
                    </div>
                </div>
            </div>

        </section>
        <!-- #finishedItems -->

        <div class="container">
            <div class="form-row">
                <asp:Repeater ID="rpIcons" runat="server">
                    <HeaderTemplate>
                        <table style="width: 100%; text-align: right; direction: rtl;">
                            <tr>
                                <th>الإمتداد</th>
                                <th>الصورة</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("FileExtension") %></td>
                            <td>
                                <img src="<%# Page.ResolveUrl( "~/" + Eval("IconPath")) %>" style="max-height: 30px; max-width: 30px;" /></td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td><%#Eval("FileExtension") %></td>
                                <td>
                                <img src="<%# Page.ResolveUrl( "~/" + Eval("IconPath")) %>" style="max-height: 30px; max-width: 30px;" /></td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <style>
                td {
                    border-bottom: 1px solid black;
                }

                    td a {
                        font-weight: bold;
                    }

                tr:hover {
                    background-color: lightgray;
                    color: black;
                    cursor: pointer;
                }
            </style>
        </div>




    </div>
</asp:Content>

