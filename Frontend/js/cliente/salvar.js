var form = document.getElementById("form")
var inputNome = document.getElementById("nome")
var inputCpf = document.getElementById("cpf")
var inputRg = document.getElementById("rg")
var inputDataDeNascimento = document.getElementById("dataDeNascimento")
var id = document.getElementById("id")
salvar(form)

function salvar(form) {

    form.addEventListener("submit", function (e) {
        e.preventDefault()

        fetch("https://localhost:5001/clientes", {
            method: "POST",
            body: JSON.stringify({
                nome: inputNome.value,
                cpf: inputCpf.value,
                rg: inputRg.value,
                dataDeNascimento: inputDataDeNascimento.value
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        }).then(function (res) {
            return res.json()
        }).then(function (data) {
            id.value = data.id
            console.log(data)
        })
    })
}

// function buscarCliente(id) {
//     inputId.value = id
//     console.log(id)
//     if(id != ""){
//         document.addEventListener("DOMContentLoaded", function (event) {
//            fetch(`https://localhost:5001/clientes/${id}`)
//            .then(res => res.json())
//            .then(data => inputId.value = data.id)
    
//         });
//         return this
//     }
// }