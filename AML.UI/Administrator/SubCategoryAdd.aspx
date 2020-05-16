<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="SubCategoryAdd.aspx.cs" Inherits="AML.UI.Administrator.SubCategoryAdd" %>

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
                    <h3>النوع الفرعي</h3>
                    <p>النوع الفرعي سوف يظهر في القائمة العليا</p>
                </div>
                <div class="form" style="direction: rtl; text-align: right;">
                    <div id="sendmessage">Your message has been sent. Thank you!</div>
                    <div id="errormessage"></div>
                    <div style="direction: rtl;">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal2" Text="النوع الرئيسي"></asp:Literal></h6>
                                <asp:DropDownList runat="server" ID="ddlMainCategory" CssClass="form-control border-info" DataTextField="NameArabic" DataValueField="Id" OnSelectedIndexChanged="ddlMainCategory_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="--النوع الرئيسي--" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <div class="validation"></div>
                            </div>
                        </div>
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
                                    <asp:Literal runat="server" ID="Literal4" Text="الوصف العربي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtArDes" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal5" Text="الوصف الانجليزي"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtEnDes" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal3" Text="محتوى الصفحة"></asp:Literal></h6>
                                <asp:DropDownList runat="server" ID="ddlPageContentType" CssClass="form-control border-info" DataTextField="Name" DataValueField="Id">
                                    <asp:ListItem Text="--المحتوى--" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal6" Text="الرابط"></asp:Literal></h6>
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                    <td><a href="<%# Page.ResolveUrl( "~/Administrator/SubCategoryAdd?Id=" + Eval("Id") +  "&categoryId=" + ddlMainCategory.SelectedValue) %>">تعديل</a></td>
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
                                    <td><a href="<%#  (((PageContentType)Eval("ContentType")).Id == 1 ? "SubCategoryEditContentText?Id=" : "SubCategoryEditContentMedia?Id=") + Eval("Id")  %>">المحتوى العربي</a></td>
                                    <td><a href="<%#  (((PageContentType)Eval("ContentType")).Id == 1 ? "SubCategoryEditContentText?lang=en&Id=" : "SubCategoryEditContentMedia?Id=") + Eval("Id")  %>">المحتوى الإنجليزي</a></td>
                                    <td><%# (((PageContentType)Eval("ContentType")).Id == 1 ? "مكتوب" : "مشاركة ملفات")  %></td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td><a href="<%# Page.ResolveUrl( "~/Administrator/SubCategoryAdd?Id=" + Eval("Id") +  "&categoryId=" + ddlMainCategory.SelectedValue) %>">تعديل</a></td>
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
                                    <td><a href="<%#  (((PageContentType)Eval("ContentType")).Id == 1 ? "SubCategoryEditContentText?Id=" : "SubCategoryEditContentMedia?Id=") + Eval("Id")  %>">المحتوى العربي</a></td>
                                    <td><a href="<%#  (((PageContentType)Eval("ContentType")).Id == 1 ? "SubCategoryEditContentText?lang=en&Id=" : "SubCategoryEditContentMedia?Id=") + Eval("Id")  %>">المحتوى الإنجليزي</a></td>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
