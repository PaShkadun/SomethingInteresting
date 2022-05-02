<template>
    <div class="container">
        <div v-if="isLoading">
            <img src="http://localhost:8080/images/loading.gif" :height="256" :width="256">
        </div>
        <div v-else-if="items.length == 0">
            <p style="color: red; font-size: 18px">Корзина пуста</p>
        </div>
        <div v-if="isSuccess">
            <p style="color: green; font-size: 18px;">Ваш заказ принят. Наш менеджер свяжется с Вами.</p>
        </div>
        <div v-if="isError">
            <p style="color: red; font-size: 18px;">Произошла ошибка. Попробуйте ещё раз чуть позже.</p>
        </div>
        <div v-for="(item, index) in items" class="item">
            <div style="width: 25%;">
                <img :src="'images/' + item.item.imgSrc" @error="defaultImg" width="256" height="256">
            </div>
            <div style="width: 25%; margin: auto;">
                <li>{{ item.item.name }}</li>
            </div>
            <div style="width: 25%; margin: auto;">
                <input type="number" min="1" max="5" value="1" class="btn" @input="input" @change="change(index, $event.target.value)"/>
            </div>
            <div style="width: 25%; margin: auto;">
                <button v-on:click="remove(item.id, index)" class="btn">Delete</button>
            </div>
        </div>
        <div v-if="items.length > 0">
            <p v-if="isAddressError" style="color: red; font-size: 18px;">Адрес не может быть пустым и не должен содержать символы '<', '>'</p>
            <input type="text" class="btn" placeholder="Адрес" v-model="address">
            <button v-on:click="order" class="btn">Order</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import AuthServer from '@/components/AuthServer'

const auth = new AuthServer()

export default {
    data() {
        return {
            userId: "",
            items: [],
            counts: [],
            isLoggedIn: false,
            model: "",
            isSuccess: false,
            isError: false,
            isLoading: false,
            isAddressError: false,
            address: ""
        }
    },
    mounted() {
        auth.getUser()
        .then((result) => {
            this.isLoggedIn = true
            this.userId = result.profile.sub
            this.isLoading = true
            
            axios.get("https://localhost:5006/bucket/getByPerson?personId=" + this.userId)
            .then((result) => {
                console.log(result)
                this.items = result.data

                result.data.forEach((current, index, array) => {
                    this.counts[index] = 1
                })
                this.isLoading = false
            })
            .catch((result) => {
                this.isLoading = false
            })
        })
    },
    methods: {
        remove(id, index) {
            this.isLoading = true
            axios.delete("https://localhost:5006/bucket/delete?id=" + id)
            .then((result) => {
                this.items.splice(index, 1)
                this.isLoading = false
            })
        },
        change(index, value) {
            console.log("change")
            console.log(value + " " + index)

            this.counts[index] = value
        },
        input(event) {
            console.log(event)
            if (event.target.value > 5) {
                event.target.value = 5
            }
            else if (event.target.value < 1) {
                event.target.value = 1
            }
        },
        order() {
            this.isLoading = false
            let mod = ""

            if (this.address.length == 0 || this.address.includes('<') || this.address.includes('>')) {
                this.isAddressError = true
                return
            }
            else {
                this.isAddressError = false
            }

            if (this.items.length == 1) {
                mod = "?itemsIds=" + this.items[0].itemId
                mod += "&counts=" + this.counts[0]
            }
            else {
                mod = "?itemsIds="

                this.items.forEach((current, index, array) => {
                    mod += current.itemId

                    if (index < (array.length - 1)) {
                        mod += "&itemsIds="
                    }
                })

                mod += "&counts="

                this.counts.forEach((current, index, array) => {
                    mod += current

                    if (index < (array.length - 1)) {
                        mod += "&counts="
                    }
                })
            }

            axios.post("https://localhost:5006/orderhistory/create" + mod, {
                orderInfo: {
                    personId: this.userId,
                    deliveryAddress: this.address
                }
            })
            .then((result) => {
                this.isSuccess = true
                this.isLoading = false

                console.log(result)

                this.items.splice(0, this.items.length)
                this.counts.splice(0, this.counts.length)
            })
            .catch((result) => {
                this.isError = true
                this.isLoading = false
                console.log(result)
            })
        },
        defaultImg(event) {
            event.target.src = window.location.origin + '/images/img.png'
        }
    }
}
</script>

<style>
    .container {
        max-width: 1320px;
        width: 90%;
        display: flex;
        flex-wrap: nowrap;
        flex-direction: column-reverse;
    }

    .item {
        margin: 20px;
        display: flex;
        flex-wrap: wrap;
    }
</style>