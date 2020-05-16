<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="CategoryAdd.aspx.cs" Inherits="AML.UI.Administrator.CategoryAdd" %>

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
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal2" Text="الوصف العربي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtArDes" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal4" Text="الوصف الانجليزي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtEnDes" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal5" Text="محتوى الصفحة"></asp:Literal></h6>
                                <asp:DropDownList runat="server" ID="ddlPageContentType" CssClass="form-control border-info" DataTextField="Name" DataValueField="Id">
                                    <asp:ListItem Text="--المحتوى--" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal3" Text="الرابط"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtURL" CssClass="form-control border-info" required></asp:TextBox>
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

        <asp:UpdatePanel runat="server" ID="upContent">
            <ContentTemplate>
                <div class="container">
                    <div class="form-row">
                        <asp:Repeater ID="rpSubCatItems" runat="server" OnItemCommand="rpSubCatItems_ItemCommand">
                            <HeaderTemplate>
                                <table style="width: 100%; text-align: right; direction: rtl;">
                                    <tr>
                                        <th></th>
                                        <th>الترتيب</th>
                                        <th>الإسم العربي</th>
                                        <th>الإسم الإنجليزي</th>
                                        <th>تعديل</th>
                                        <th>تعديل</th>
                                        <th>
                                            <asp:Literal runat="server" ID="litContentType" Text="نوع المحتوى"></asp:Literal></th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a href="<%# Page.ResolveUrl( "~/Administrator/CategoryAdd?Id=" + Eval("Id")) %>">تعديل</a></td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="MoveUp" CommandName="moveup" CommandArgument='<%# Eval("SortId") %>'
                                            Text="" CssClass="fa fa-arrow-up"
                                            Enabled="<%# Container.ItemIndex == 0 ? false : true %>">
                                        </asp:LinkButton>
                                        <%# Eval("SortId") %>
                                        <asp:LinkButton runat="server" ID="MoveDown" CommandName="movedown" CommandArgument='<%# Eval("SortId") %>'
                                            Text="" CssClass="fa fa-arrow-down"
                                            Enabled="<%# Container.ItemIndex== ((IList)((Repeater)Container.Parent).DataSource).Count-1  ? false : true %>">
                                        </asp:LinkButton>
                                    </td>
                                    <td><%#Eval("NameArabic") %></td>
                                    <td><%#Eval("NameEnglish") %></td>
                                    <td><a href="<%# (((PageContentType)Eval("ContentType")).Id == 1 ? "MainCategoryEditContentText?Id=" : "MainCategoryEditContentMedia?Id=") + Eval("Id") %>">المحتوى العربي</a></td>
                                    <td><a href="<%# (((PageContentType)Eval("ContentType")).Id == 1 ? "MainCategoryEditContentText?Id=" : "MainCategoryEditContentMedia?Id=") + Eval("Id")  + "&lang=en" %>">المحتوى الإنجليزي</a></td>
                                    <td><%# (((PageContentType)Eval("ContentType")).Id == 1 ? "مكتوب" : "مشاركة ملفات")  %></td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td><a href="<%# Page.ResolveUrl( "~/Administrator/CategoryAdd?Id=" + Eval("Id")) %>">تعديل</a></td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="MoveUp" CommandName="moveup" CommandArgument='<%# Eval("SortId") %>'
                                            Text="" CssClass="fa fa-arrow-up"
                                            Enabled="<%# Container.ItemIndex == 0 ? false : true %>">
                                        </asp:LinkButton>
                                        <%# Eval("SortId") %>
                                        <asp:LinkButton runat="server" ID="MoveDown" CommandName="movedown" CommandArgument='<%# Eval("SortId") %>'
                                            Text="" CssClass="fa fa-arrow-down"
                                            Enabled="<%# Container.ItemIndex== ((IList)((Repeater)Container.Parent).DataSource).Count-1  ? false : true %>">
                                        </asp:LinkButton>
                                    </td>
                                    <td><%#Eval("NameArabic") %></td>
                                    <td><%#Eval("NameEnglish") %></td>
                                    <td><a href="<%# (((PageContentType)Eval("ContentType")).Id == 1 ? "MainCategoryEditContentText?Id=" : "MainCategoryEditContentMedia?Id=") + Eval("Id") %>">المحتوى العربي</a></td>
                                    <td><a href="<%# (((PageContentType)Eval("ContentType")).Id == 1 ? "MainCategoryEditContentText?Id=" : "MainCategoryEditContentMedia?Id=") + Eval("Id") + "&lang=en" %>">المحتوى الإنجليزي</a></td>
                                    <td><%# (((PageContentType)Eval("ContentType")).Id == 1 ? "مكتوب" : "مشاركة ملفات")  %></td>
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>






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
</asp:Content>
