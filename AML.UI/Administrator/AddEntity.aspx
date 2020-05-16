<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="AddEntity.aspx.cs" Inherits="AML.UI.Administrator.AddEntity" %>

<%@ Import Namespace="AML.Domain.Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="about">

        <section id="contact" class="section-bg wow fadeInUp">
            <div class="container">

                <div class="section-header">
                    <h3>الجهات</h3>
                    <p>الجهات المعتمدة للدخول إلى المنصة</p>
                </div>
                <div class="form-row" style="direction: rtl; text-align: right;">
                    <asp:Literal runat="server" ID="litSendMsg" Mode="PassThrough"></asp:Literal>

                    <asp:Literal runat="server" ID="litErrorMsg" Mode="PassThrough"></asp:Literal>

                    <div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="litArName" Text="الإسم العربي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtArName" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal1" Text="الإسم الإنجليزي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtEnName" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal3" Text="شعار الجهة"></asp:Literal></h6>
                                <asp:FileUpload ID="fuDocument" runat="server" CssClass="form-control border-info" required></asp:FileUpload>
                                <div class="validation"></div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group col-md-12">
                        <asp:Button Text="حفظ" runat="server" ID="btnSave" OnClick="btnSave_Click" CssClass="border-0 btn-dark form-control" />
                    </div>
                </div>
            </div>
            <div class="container" style="padding-top: 70px;">
                <div class="form-row">
                    <asp:Repeater ID="rpSubCatItems" runat="server">
                        <HeaderTemplate>
                            <table style="width: 100%; text-align: right; direction: rtl;">
                                <tr>
                                    <th></th>
                                    <th>الإسم العربي</th>
                                    <th>الإسم الإنجليزي</th>
                                    <th>الصورة</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><a href="<%# Page.ResolveUrl( "~/Administrator/AddEntity?Id=" + Eval("Id")) %>">تعديل</a></td>
                                <td><%#Eval("NameArabic") %></td>
                                <td><%#Eval("NameEnglish") %></td>
                                <td>
                                    <img src="<%# Page.ResolveUrl( "~/" + Eval("LogoURL")) %>" style="max-height: 30px; max-width: 30px;" /></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td><a href="<%# Page.ResolveUrl( "~/Administrator/AddEntity?Id=" + Eval("Id")) %>">تعديل</a></td>
                                <td><%#Eval("NameArabic") %></td>
                                <td><%#Eval("NameEnglish") %></td>
                                <td>
                                    <img src="<%# Page.ResolveUrl( "~/" + Eval("LogoURL")) %>" style="max-height: 30px; max-width: 30px;" /></td>
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
        </section>
        <!-- #finishedItems -->
    </div>
</asp:Content>
