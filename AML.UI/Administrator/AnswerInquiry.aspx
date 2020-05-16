<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="AnswerInquiry.aspx.cs" Inherits="AML.UI.Administrator.AnswerInquiry" %>

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
                                    <asp:Literal runat="server" ID="Literal1" Text="إسم الجهة"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtEntityName" ReadOnly="true" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal2" Text="إسم الشخص"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtSubmitterName" ReadOnly="true" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-12">
                                <h6>
                                    <asp:Literal runat="server" ID="litArName" Text="عنوان الإستفسار"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtTitle" ReadOnly="true" CssClass="form-control border-info" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-12">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal5" Text="التفاصيل"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtDesc" TextMode="MultiLine" ReadOnly="true" CssClass="form-control border-info" Rows="4" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-12">
                                <h6>
                                    <asp:Literal runat="server" ID="Literal3" Text="الإجابة"></asp:Literal></h6>
                                <asp:TextBox Text="" runat="server" ID="txtAnswer" TextMode="MultiLine" CssClass="form-control border-info" Rows="4" required></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-12">
                                <asp:CheckBoxList runat="server" ID="checkItems" CssClass="form-control border-info checkboxList" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="وضع الاستفسار على العام" Selected="True" Value="isPublic"></asp:ListItem>
                                    <asp:ListItem Text="إرسال بريد إلكتروني" Selected="True" Value="sendEmail"></asp:ListItem>
                                </asp:CheckBoxList>
                                </div>
                            <div class="form-group col-md-12">
                                <asp:Button Text="حفظ" runat="server" ID="btnSave" OnClick="btnSave_Click" CssClass="border-0 btn-dark form-control" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </div>
    <style>
        .checkboxList input
        {
            margin-left: 10px !important;
        }
        .checkboxList label
        {
            padding-left: 10px;
        }
        .checkboxList td{
            
        }
    </style>
</asp:Content>
