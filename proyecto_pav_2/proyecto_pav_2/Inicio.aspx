<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Capa_de_presentacion.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-md-3">
                <p class="lead">Listado de Paquetes Disponibles</p>
                <div class="list-group">
                    <asp:Repeater ID="rpt_temporadas" runat="server">
                        <ItemTemplate>
                            <a href='Inicio.aspx?id_temporada=<%# Eval("id_temporada") %>' class="list-group-item"><%# Eval("nombre") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="col-md-9">

                <div class="row carousel-holder">

                    <div class="col-md-12">
                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                            <ol class="carousel-indicators">
                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                            </ol>
                            <div class="carousel-inner">
                                <div class="item active">
                                    <img class="slide-image" src="img/carrucel_1.jpg" alt="">
                                </div>
                                <div class="item">
                                    <img class="slide-image" src="img/carrucel_2.jpg" alt="">
                                </div>
                                <div class="item">
                                    <img class="slide-image" src="img/carrucel_3.jpg" alt="">
                                </div>
                            </div>
                            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                            </a>
                            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right"></span>
                            </a>
                        </div>
                    </div>

                </div>

                <div class="row">

                    <asp:Repeater ID="rpt_paquetes" runat="server" OnItemCommand="rpt_paquetes_ItemCommand">

                        <ItemTemplate>

                            <div class="col-sm-4 col-lg-4 col-md-4">
                                <div class="thumbnail">
                                    <div class="caption-full">
                                        <h4 class="text-left"><%# Eval("nombre_paquete") %></h4>
                                        <h5 class="text-left"><%# Eval("destino.nombre") %></h5>
                                        <h5 class="text-left">Días:<%# Eval("cantidad_dias") %></h5>
                                        <h5 class="text-left">Noches:<%# Eval("cantidad_noches") %></h5>
                                        <h4 class="pull-right"><%# Eval("precio", "{0:c}") %></h4>
                                        <asp:Button ID="btn_comprar" runat="server" Text="Comprar" CssClass="btn btn-primary" CommandName="Comprar" CommandArgument='<%#Eval("id_paquete_turistico") %>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
