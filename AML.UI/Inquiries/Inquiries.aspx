<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inquiries.aspx.cs" Inherits="AML.UI.Inquiries.Inquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="contact" class="section-bg text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="إستفسارات"></asp:Literal></h3>
                <p>
                    <asp:Literal ID="litTitle" runat="server" Text="​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​ تعرض هذه الصفحة الإستفسارات الواردة من الجهات المشاركة في المنصة، وسيتم تحديث وتوسيع هذه الصفحة دورياً. إذا كان لديك أي سؤال الرجاء إرساله من خلال النموذج. نرحب بأسئلتكم واقتراحاتكم."></asp:Literal>
                </p>
            </div>
            <div class="form-row">


                <section id="services">
                    <div class="container">
                        <div class="row">
                            <asp:Repeater ID="rpInquiries" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-12" style="visibility: visible; animation-duration: 1.4s; animation-name: bounceInUp;">
                                        <div class="icon"><i class="ion-ios-bookmarks-outline"></i></div>
                                        <h5 class="title"><a href="#"><%# Eval("Name") %></a></h5>
                                        <p class="description" title="<%# Eval("Description") %>"><%# Eval("Description").ToString().Length > 100 ?  (Eval("Description").ToString() + "..." ) : Eval("Description") %></p>
                                        <div class="col-md-11">
                                            <p style="font-size: 0.7em; margin-top: 5px; color: white; background-color: black; display: inline; padding: 1px 5px; border-radius: 20px; font-family: 'Droid Arabic Kufi';">من خلال <%# EntityService.GetById(int.Parse(GetUserInformation(Eval("UserId").ToString()).EntityName), selectedLanguage).Name %></p>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <asp:Repeater ID="rpAnswers" runat="server" DataSource='<%# (Eval("Answers")) %>'>
                                                <ItemTemplate>
                                                    <div class="col-md-1">
                                                        <div class="icon1" style="padding: 0 10px; display: inline-block; color: #18d26e;"><i class="fa fa-comment"></i></div>
                                                    </div>
                                                    <div class="col-md-11">
                                                        <p style="display: inline-block; font-size: 0.8em;">الإجابة: <%# Eval("Answer")%></p>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <p style="font-size: 0.7em; margin-top: 5px; color: white; background-color: black; display: inline; padding: 1px 5px; border-radius: 20px; font-family: 'Droid Arabic Kufi';">من خلال <%# EntityService.GetById(int.Parse(GetUserInformation(Eval("UserId").ToString()).EntityName), selectedLanguage).Name %></p>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>

                    </div>
                </section>
            </div>
        </div>

    </section>
</asp:Content>
