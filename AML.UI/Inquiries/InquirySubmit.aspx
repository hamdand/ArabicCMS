<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InquirySubmit.aspx.cs" Inherits="AML.UI.Inquiries.InquirySubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="contact" class="section-bg wow fadeInUp text-align-lang">
        <div class="container">
            <div class="section-header">
                <h3>
                    <asp:Literal runat="server" Text="إستفسار جديد"></asp:Literal></h3>
                <p>
                    <asp:Literal ID="litTitle" runat="server" Text="​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​ تعرض هذه الصفحة الأسئلة الأكثر شيوعاً، وسيتم تحديث وتوسيع هذه الصفحة دورياً. إذا كان لديك أي سؤال الرجاء إرساله من خلال النموذج أدناه. نرحب بأسئلتكم واقتراحاتكم."></asp:Literal>
                </p>
            </div>
            <div class="form">
                <asp:Literal runat="server" ID="litSendMsg" Mode="PassThrough"></asp:Literal>

                <asp:Literal runat="server" ID="litErrorMsg" Mode="PassThrough"></asp:Literal>

                <div class="form-group col-md-12">
                    <h6>
                        <asp:Literal runat="server" ID="litArName" Text="عنوان الإستفسار"></asp:Literal></h6>
                    <asp:TextBox Text="" runat="server" ID="txtArName" CssClass="form-control border-info" required></asp:TextBox>
                    <div class="validation"></div>
                </div>
                <div class="form-group col-md-12">
                    <h6>
                        <asp:Literal runat="server" ID="Literal1" Text="التفاصيل"></asp:Literal></h6>
                    <asp:TextBox Text="" runat="server" ID="txtDesc" TextMode="MultiLine" CssClass="form-control border-info" Rows="4" required></asp:TextBox>
                    <div class="validation"></div>
                </div>
            </div>
            <div class="text-center">
                <asp:Button Text="حفظ" runat="server" ID="btnSave" OnClick="btnSave_Click" CssClass="border-0 btn-dark form-control" />
            </div>
        </div>
    </section>
</asp:Content>
