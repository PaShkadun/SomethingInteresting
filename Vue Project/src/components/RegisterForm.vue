<template>
    <div class="form" style="margin-top: 50px;">
        <li v-if="!correctName">Имя не может быть пустым и содержать что-либо, кроме букв</li>
        <li v-if="existsEmail">Такой email уже существует</li>
        <input v-model="name" placeholder="Имя" type="text" class="btn">
        <li v-if="!correctUsername">Вид логина: aaaa@aaa.aaa</li>
        <input v-model="email" type="text" placeholder="email@some.ru" class="btn">
        <li v-if="!correctPassword">Пароль должен содержать строчную, прописную буквы, спец символ и цифру (>= 6 символов)</li>
        <input v-model="password" type="password" placeholder="password" class="btn">
        <li v-if="!equalPasswords">Пароли не совпадают</li>
        <input v-model="repeatPassword" type="password" placeholder="repeat pass" class="btn">
        <button v-on:click="registation" class="btn">Register</button>
    </div>
</template>

<script>
import axios from "axios"

export default {
    data() {
        return {
            email: "",
            password: "",
            repeatPassword: "",
            name: "",
            correctPassword: true,
            equalPasswords: true,
            correctUsername: true,
            correctName: true,
            existsEmail: false,
            regexEmail: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/,
            regexName: /([A-z])\w+/
        }
    },
    methods: {
        registation() {
            this.correctPassword = true
            this.existsEmail = false

            if (this.regexEmail.test(this.email) == false) {
                this.correctUsername = false
            }
            else {
                this.correctUsername = true
            }

            if (this.name.length < 3 || this.regexName.test(this.name) == "has-error") {
                this.correctName = false
            }
            else {
                this.correctName = true
            }

            if (this.password.length < 6) {
                this.correctPassword = false
                return
            }
            else {
                this.correctPassword = true
            }

            if (this.password == this.repeatPassword) {
                this.equalPasswords = true
            }
            else {
                this.equalPasswords = false
            }

            if (this.equalPasswords && this.correctName && this.correctUsername) {
                axios.post("https://localhost:5001/register", {
                    name: this.name,
                    email: this.email,
                    password: this.password
                })
                .then((result) => {
                    console.log(result)

                    if (result.data.email == "error") {
                        this.existsEmail = true
                    }

                    if (result.data.password == "error") {
                        this.correctPassword = false
                    }

                    if (!this.existsEmail && this.correctPassword) {
                        axios.post("https://localhost:5006/person/create", {
                            name: this.name,
                            id: result.data.userId,
                            permissionId: 1
                        })
                        .then((res) => {
                            console.log(res)
                        })
                    }
                })
                .catch((result) => {

                })
            }
        }
    }
}
</script>

<style>
    .form li {
        padding: 0;
        margin: 0;
        color: red;
    }

    .form {
        display: inline-grid;
    }

    .btn {
        color: #42b983;
        font-weight: bold;
        background-color: #007bff;
        border-color: #007bff;
        display: inline-block;
        font-weight: 400;
        text-align: center;
        vertical-align: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        background-color: transparent;
        border: 1px solid #42b983;
        padding: .375rem .75rem;
        margin: 10px;
        font-size: 1rem;
        line-height: 1.5;
        border-radius: .25rem;
        transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
    }

</style>