<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="MainCategoryEditContentMedia.aspx.cs" Inherits="AML.UI.Administrator.MainCategoryEditContentMedia" %>

<%@ Import Namespace="AML.Domain.Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
                    <h3>
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal></h3>
                    <p>
                        <asp:Literal ID="litDes" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="form" style="direction: rtl; text-align: right;">
                    <asp:Literal runat="server" ID="litSendMsg" Mode="PassThrough"></asp:Literal>

                    <asp:Literal runat="server" ID="litErrorMsg" Mode="PassThrough"></asp:Literal>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <h6>
                                <asp:Literal runat="server" ID="litArName" Text="الملف العربي"></asp:Literal></h6>
                            <asp:FileUpload ID="fuDocument" runat="server" CssClass="form-control border-info" required></asp:FileUpload>
                        </div>
                        <div class="form-group col-md-6">
                            <h6>
                                <asp:Literal runat="server" ID="Literal1" Text="إسم الملف"></asp:Literal></h6>
                            <asp:TextBox ID="txtFileName" runat="server" CssClass="form-control border-info" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <h6>
                                <asp:Literal runat="server" ID="Literal2" Text="وصف الملف"></asp:Literal></h6>
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control border-info" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <h6>
                                <asp:Literal runat="server" ID="Literal3" Text="تاريخ الملف"></asp:Literal></h6>
                            <asp:TextBox ID="txtDocDate" TextMode="Date" class="form-control border-info" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <h6>
                                <asp:Literal runat="server" ID="Literal4" Text="لغة الملف"></asp:Literal></h6>
                            <asp:RadioButtonList ID="rbLang" runat="server" RepeatDirection="Horizontal" CssClass="form-control border-info">
                                <asp:ListItem Text=" عربي " Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="English" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>

                        </div>
                    </div>
                    <div class="text-center">
                        <asp:Button Text="حفظ" runat="server" ID="btnSave" CssClass="border-0 btn-dark form-control" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="container">
        <div class="form-row">
            <asp:Repeater ID="rpFiles" runat="server" OnItemCommand="rpFiles_ItemCommand">
                <HeaderTemplate>
                    <table style="width: 100%; text-align: right; direction: rtl;">
                        <tr>
                            <th>إسم الملف</th>
                            <th>لغة الملف</th>
                            <th class="d-none d-lg-block">تاريخ الإنشاء</th>
                            <th></th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr title="<%#Eval("Name") %>">
                        <td><a href="<%# Page.ResolveUrl("~/" + Eval("FilePath"))  %>" target="_blank"><%# Eval("Name").ToString().Length>30 ? Eval("Name").ToString().Substring(0,20)  + "..." : Eval("Name") %></a></td>
                        <td>
                            <%# bool.Parse(Eval("IsEnglishFile").ToString()) == true ? "الإنجليزية": "عربي"  %></td>
                        <td  class="d-none d-lg-table-cell">
                            <%#Eval("Created") %></td>
                        <td>
                            <asp:LinkButton ID="btnDelete" CommandArgument='<%#Eval("Id") %>' CommandName="Delete" runat="server" Text="حذف" OnClientClick="return myFunction()"></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
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
    <script>
        function myFunction() {
            return confirm("هل أنت متأكد من عملية الحذف؟");
        }
    </script>
</asp:Content>
