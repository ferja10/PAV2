<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Capa_de_presentacion.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="col-md-5">
            <div class="form-area">
                <form role="form">
                    <br style="clear: both">
                    <h3 style="margin-bottom: 25px; text-align: center;">CONTACTO</h3>
                    <div class="form-group">
                        <asp:TextBox ID="txt_nombre"  CssClass="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="Requiere que ingrese un nombre" ControlToValidate="txt_nombre" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <input type="text" class="form-control" id="email" name="email" placeholder="Email">
                    </div>
                    <div class="form-group">
                        <input type="text" class="form-control" id="mobile" name="mobile" placeholder="Telefono">
                    </div>
                    <div class="form-group">
                        <textarea class="form-control" type="textarea" id="message" placeholder="Mensaje" maxlength="140" rows="7"></textarea>
                    </div>
                    <asp:Button ID="btn_enviar" runat="server" Text="Enviar" CssClass="btn btn-primary pull-right" OnClick="btn_enviar_Click" />
                </form>
            </div>
        </div>
    </div>

</asp:Content>
