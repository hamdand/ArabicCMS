<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Media.aspx.cs" Inherits="AML.UI.SubCategoryPageContent.Media" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="about">
        <div class="container">

            <header class="section-header wow fadeInUp" style="visibility: visible; animation-name: fadeInUp;">
                <h3>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal></h3>
                <p>
                    <asp:Literal ID="litDes" runat="server"></asp:Literal></p>
            </header>

            <div class="row" style="direction: rtl;">

                <asp:Repeater ID="rpDocuments" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 box wow bounceInUp" data-wow-duration="1.4s" style="visibility: visible; animation-duration: 1.4s; animation-name: bounceInUp;">
                            <div class="icon"><a href="<%# Page.ResolveUrl("~/" + Eval("FilePath")) %>" target="_blank"><img src="<%# Page.ResolveUrl( "~/" + Eval("FileIcon")) %>" class="mediaIcon"/></a></div>
                            <h4 class="title" style="font-size: 0.9rem"><a href="<%# Page.ResolveUrl("~/" + Eval("FilePath")) %>" target="_blank"><%# Eval("Name") %></a></h4>
                            <div class="text-align-lang"><%#Eval("Created") %></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>


