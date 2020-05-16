<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Site.Master" AutoEventWireup="true" CodeBehind="MainCategoryEditContentText.aspx.cs" Inherits="AML.UI.Administrator.MainCategoryEditContentText" ValidateRequest="false" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
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
                        <div class="form-group col-md-12">
                            <FTB:FreeTextBox ID="FreeTextBox1" OnSaveClick="FreeTextBox1_SaveClick" Width="100%"
                                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
                                runat="Server"
                                DesignModeCss="/demos/demo.css" />
                        </div>
                    </div>
                    <div class="text-center">
                        <asp:Button Text="حفظ" runat="server" ID="btnSave" OnClick="FreeTextBox1_SaveClick" CssClass="border-0 btn-dark form-control" />
                    </div>
                </div>
            </div>
        </section>
    </div>

</asp:Content>
