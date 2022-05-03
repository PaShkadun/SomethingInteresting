<template>
    <div>
        <div v-if="permission == 'admin'">
            <a href="https://localhost:5006/index.html">Админ панель</a>
        </div>
        <li v-if="changePasswordCode == 0" style="color: green; font-size: 18px;">Пароль успешно изменён</li>
        <li v-if="changePasswordCode == 1" style="color: red; font-size: 18px;">Текущий пароль введён неверно</li>
        <li v-if="changePasswordCode == 2" style="color: red; font-size: 18px;">Новый пароль должен содержать строчкую, прописную букву, цифру и спец симлов (>= 6 символов)</li>
        <li v-if="changePasswordCode == 3" style="color: red; font-size: 18px;">Новый пароль не должен совпадать со старым.</li>
        <li v-if="changePasswordCode == 4" style="color: red; font-size: 18px;">Новый пароль не совпадает.</li>
        <div v-if="!isLoadingChange">
            <input type="password" v-model="oldPassword" placeholder="Старый пароль" class="btn">
            <input type="password" v-model="newPassword" placeholder="Новый пароль" class="btn">
            <input type="password" v-model="newPasswordRepeat" placeholder="Новый пароль" class="btn">
            <button class="btn" @click="changePassword">Поменять пароль</button>
        </div>
        <div v-else>
            <img src="http://localhost:8080/images/loading.gif">
        </div>
        <div class="history">
            <div v-for="OH in orderHistory">
                <li>Номер заказа: {{ OH.id }}</li>
                <li>Дата заказа: {{ OH.orderInfo.date }}</li>
                <div v-for="item in OH.orderItem" class="history-item">
                    <img :src="'http://localhost:8080/images/' + item.item.imgSrc" @error="defaultImg" :width="256" :height="256">
                    <li>{{ item.item.name }}</li>
                    <li>{{ item.item.description }}</li>
                    <li>{{ item.itemCount }} шт</li>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import AuthServer from '@/components/AuthServer'
import axios from 'axios'

const auth = new AuthServer()

export default {
    data() {
        return {
            changePasswordCode: -1,
            oldPassword: "",
            newPassword: "",
            newPasswordRepeat: "",
            isLoadingChange: false,
            userId: "",
            userEmail: "",
            orderHistory: [],
            permission: ""
        }
    },
    mounted() {
        auth.getUser()
        .then((result) => {
            this.userId = result.profile.sub
            this.userEmail = result.profile.name

            axios.get("https://localhost:5006/orderhistory/getByPerson?personId=" + this.userId)
            .then((result) => {
                console.log(result)
                this.orderHistory = result.data
            })
            .catch((result) => {
                console.log(result)
            })

            this.getPermission()
        })
    },
    methods: {
        defaultImg(event) {
            event.target.src = window.location.origin + '/images/img.png'
        },
        changePassword() {
            this.changePasswordCode = -1

            if (this.newPassword != this.newPasswordRepeat) {
                this.changePasswordCode = 4
                return
            }
            else if (this.newPassword == this.oldPassword) {
                this.changePasswordCode = 3
                return
            }
            else if (this.newPassword.length < 6) {
                this.changePasswordCode = 2
                return
            }

            this.isLoadingChange = true
            let user

            user = result.profile.name

            axios.post("https://localhost:5001/ChangePassword", {
                email: this.userEmail,
                oldPassword: this.oldPassword,
                newPassword: this.newPassword
            })
            .then((result) => {
                console.log(result)
                this.changePasswordCode = result.data
                this.isLoadingChange = false
            })
            .catch((result) => {
                console.log(result)
                this.isLoadingChange = false
            })
        },
        getPermission() {
            return axios.get("https://localhost:5006/person/getById?id=" + this.userId)
            .then((result) => {
                let role = result.data.permission
                this.permission = role.role
            })
        }
    }
}
</script>

<style>
.history-item {
    display: flex;
    justify-content: space-between;
}
</style>