var getInput = document.querySelector('#txt_userName');
var getInputPass = document.querySelector('#txt_userPassWord')
var getPassConfirm = document.querySelector('#txt_userPasswordConfirm')
var getSpan1 = document.querySelector('.errorMessage__1')
var getSpan2 = document.querySelector('.errorMessage__2')
var getSpan3 = document.querySelector('.errorMessage__3')
var getBtnLogin = document.querySelector('.btn__Login')
var formLogin = document.querySelector('#form__login')
var formRegister = document.querySelector('#form__register')

console.log(getPassConfirm)
console.log(formRegister)

function handleEventOnBlur() {

    getInput.onblur = function () {
        if (!this.value) {
            this.parentElement.classList.add('invalid');
            getSpan1.innerText = "Vui lòng nhập trường này!"
        } else {
            this.parentElement.classList.remove('invalid');
            getSpan1.innerText = ""
        }
    }
    getInputPass.onblur = function () {
        if (!this.value) {
            this.parentElement.classList.add('invalid');
            getSpan2.innerText = "Vui lòng nhập trường này!"
        } else {
            this.parentElement.classList.remove('invalid');
            getSpan2.innerText = ""
        }
    }


}

function handleEventOnInput() {
    getInput.oninput = function () {
        this.parentElement.classList.remove('invalid');
        getSpan1.innerText = ""
    }

    getInputPass.oninput = function () {
        this.parentElement.classList.remove('invalid');
        getSpan2.innerText = ""
    }

    getPassConfirm.oninput = function () {
        this.parentElement.classList.remove('invalid');
        getSpan3.innerText = ""
    }
}


function handleButton() {

    getBtnLogin.onclick = function () {
        if (!getInput.value) {
            getInput.parentElement.classList.add('invalid');
            getSpan1.innerText = "Vui lòng nhập trường này!"

        }
        if (!getInputPass.value) {
            getInputPass.parentElement.classList.add('invalid');
            getSpan2.innerText = "Vui lòng nhập trường này!"
        }
    }
}

// function handleSubmitForm() {
//     formLogin.onsubmit = function(e){
//         if(!getInput.value && !getInputPass.value){
//             e.preventDefault();
//         }
//     }
// }

function handleSubmitRegister() {
    formRegister.onsubmit = function (e) {
        if (!getInput.value && !getInputPass.value && !getPassConfirm.value) {
            e.preventDefault();
        }

        if (getInputPass.value != getPassConfirm.value) {
            e.preventDefault();
            getPassConfirm.parentElement.classList.add('invalid');
            getSpan3.innerText = "Mật khẩu nhập lại không đúng!"
        }
    }
}

function start() {
    handleEventOnBlur();
    handleEventOnInput();
    handleButton();
    // handleSubmitForm();
    handleSubmitRegister();
}

start();