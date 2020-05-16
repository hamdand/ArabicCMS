<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AML.UI._Default" %>

<%@ Import Namespace="AML.Domain.Application" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--==========================
      Intro Section
    ============================-->
    <section id="intro">
        <div class="intro-container">
            <div id="introCarousel" class="carousel  slide carousel-fade" data-ride="carousel">

                <ol class="carousel-indicators"></ol>

                <div class="carousel-inner" role="listbox">
                    <asp:Repeater runat="server" ID="rpNews">
                        <ItemTemplate>
                            <div class="<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>">
                                <div class="carousel-background">
                                    <img src="<%# Page.ResolveUrl("~/" +  Eval("ImageUrl")) %>" alt="">
                                </div>
                                <div class="carousel-container">
                                    <div class="carousel-content">
                                        <h2><%# Eval("Name") %></h2>
                                        <p><%# Eval("Description").ToString().Length > 300 ? Eval("Description").ToString().Substring(0,300) + "..."  :Eval("Description") %></p>
                                        <a href="#featured-services" class="btn-get-started scrollto">عرض المزيد</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>

                <a class="carousel-control-prev" href="#introCarousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon ion-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>

                <a class="carousel-control-next" href="#introCarousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon ion-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>

            </div>
        </div>
    </section>
    <!-- #intro -->

    <!--==========================
      Footer
    ============================-->

</asp:Content>
