<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQs.aspx.cs" Inherits="AML.UI.FAQs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="contact" class="section-bg wow fadeInUp text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="أسئلة متكررة"></asp:Literal></h3>
                <p>
                    <asp:Literal ID="litTitle" runat="server" Text="​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​ تعرض هذه الصفحة الأسئلة الأكثر شيوعاً، وسيتم تحديث وتوسيع هذه الصفحة دورياً. إذا كان لديك أي سؤال الرجاء إرساله من خلال النموذج أدناه. نرحب بأسئلتكم واقتراحاتكم."></asp:Literal></p>
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="panel-group">
                        <div class="panel panel-default">
                            <asp:Repeater ID="rpFAQs" runat="server">
                                <ItemTemplate>
                                    <div class="panel-heading">
                                        <h6 class="panel-title FAQs"><a data-toggle="collapse" href="<%# "#collapse" + Eval("Id") %>" style="color: black; display: block;"><span class="fa fa-question-circle" aria-hidden="true" style="padding-left: 10px; padding-right: 10px; font-size: 1rem; color: rgb(23, 162, 184)"></span><%# Eval("Name") %></a>
                                        </h6>
                                    </div>
                                    <div id="<%# "collapse" + Eval("Id") %>" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <p><%# Eval("Description") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
