<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="PendingInquiries.aspx.cs" Inherits="AML.UI.Administrator.PendingInquiries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="about">

        <section id="contact" class="section-bg wow fadeInUp">
            <div class="container">

                <div class="section-header">
                    <h3>الجهات</h3>
                    <p>الجهات المعتمدة للدخول إلى المنصة</p>
                </div>
            </div>
            <div class="container">
                <div class="form-row">
                    <asp:Repeater ID="rpSubCatItems" runat="server" OnItemCommand="rpSubCatItems_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 100%; text-align: right; direction: rtl;">
                                <tr>
                                    <th></th>
                                    <th></th>
                                    <th>الجهة</th>
                                    <th>السؤال</th>
                                    <th>الحالة</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><a href="<%# Page.ResolveUrl( "~/Administrator/AnswerInquiry?Id=" + Eval("Id")) %>">تعديل</a></td>
                                <td><asp:LinkButton runat="server" ID="btnDelete" CommandName="DeleteItem" CommandArgument='<%#Eval("Id") %>' OnClientClick='return confirm("هل أنت متأكد من عملية الحذف؟")'>حذف</asp:LinkButton></td>
                                <td><%# EntityService.GetById(int.Parse(GetUserInformation(Eval("UserId").ToString()).EntityName), AML.Domain.Helper.Lang.Arabic.ToString()).Name %></td>
                                <td><%#Eval("Name") %></td>
                                <td><%# (bool)Eval("IsClosed") ? "<span style=\"color: green; \">تمت الإجابة</span>" : "<span style=\"color: red; \">بإنتظار الرد</span>"  %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <style>
                    td {
                        border: 1px solid lightgray;
                    }

                        td a {
                            font-weight: bold;
                        }

                    tr:hover {
                        background-color: lightgray;
                        color: black;
                        cursor: pointer;
                    }
                    th{
                        background-color: lightgray;
                        border-bottom: 1px solid black;
                    }
                    table{
                        border: 1px solid black;
                    }

                </style>
            </div>
        </section>
        <!-- #finishedItems -->
    </div>
</asp:Content>
