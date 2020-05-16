<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="AML.UI.Administrator.AddNews" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #main {
            padding-top: 50px;
        }

        .form-control {
            height: calc(2.25rem + 8px);
        }
    </style>
    <div id="main">

        <section id="contact" class="section-bg wow fadeInUp">
            <div class="container">

                <div class="section-header">
                    <h3>النوع الرئيسي</h3>
                    <p>النوع الرئيسي سوف يظهر في القائمة العليا</p>
                </div>
                <div class="form" style="direction: rtl; text-align: right;">
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
                            <div class="form-group col-md-12">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal3" Text="صورة الخبر"></asp:Literal></h6>
                                <asp:FileUpload ID="fuDocument" runat="server" CssClass="form-control border-info" required></asp:FileUpload>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal2" Text="الوصف العربي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtArDes" TextMode="MultiLine" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal4" Text="الوصف الانجليزي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtEnDes" TextMode="MultiLine" CssClass="form-control border-info" required></asp:TextBox>
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
                <asp:Repeater ID="rpSubCatItems" runat="server">
                    <HeaderTemplate>
                        <table style="width: 100%; text-align: right; direction: rtl;">
                            <tr>
                                <th></th>
                                <th>الإسم العربي</th>
                                <th>الإسم الإنجليزي</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><a href="<%# Page.ResolveUrl( "~/Administrator/AddNews?Id=" + Eval("Id")) %>">تعديل</a></td>
                            
                            <td><%#Eval("NameArabic") %></td>
                            <td><%#Eval("NameEnglish") %></td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td><a href="<%# Page.ResolveUrl( "~/Administrator/AddNews?Id=" + Eval("Id")) %>">تعديل</a></td>
                            
                            <td><%#Eval("NameArabic") %></td>
                            <td><%#Eval("NameEnglish") %></td>
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
