const inputNombre = document.getElementById('nombre');
const inputTelefono = document.getElementById('telefono');
const inputCorreo = document.getElementById('correo');
const inputAsunto = document.getElementById('asunto');
const inputMensaje = document.getElementById('mensaje');

function enviarFormulario(){
    document.cookie = "Nombre=" + nombrePersona + ";";
    document.cookie = "Telefono=" + telefonoPersona + ";";
    document.cookie = "Correo=" + correoPersona + ";";
    document.cookie = "Asunto=" + asuntoPersona + ";";
    document.cookie = "Mensaje=" + mensajePersona + ";";
    localStorage.setItem("nombre", inputNombre);
    localStorage.setItem("telefono", inputTelefono);
    localStorage.setItem("correo", inputCorreo);
    localStorage.setItem("mensaje", inputMensaje);
    sessionStorage.setItem("nombre", inputNombre);
    sessionStorage.setItem("telefono", inputTelefono);
    sessionStorage.setItem("correo", inputCorreo);
    sessionStorage.setItem("asunto", inputAsunto);
    sessionStorage.setItem("mensaje", inputMensaje);
    console.log('Enviado formulario');

    return true;
}
