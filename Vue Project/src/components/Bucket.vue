<template>
    <div class="container">
        <div v-for="(item, index) in items" class="item">
            <div style="width: 33%;">
                <img :src="'images/' + item.item.imgSrc" width="256" height="256">
            </div>
            <div style="width: 33%;">
                <li>{{ item.item.name }}</li>
            </div>
            <div style="width: 33%; margin: auto;">
                <button v-on:click="remove(item.id, index)" class="btn">Delete</button>
            </div>
        </div>
        <div v-if="items.length > 0">
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
            isLoggedIn: false,
            model: ""
        }
    },
    mounted() {
        auth.getUser()
        .then((result) => {
            this.isLoggedIn = true
            this.userId = result.profile.sub
            
            axios.get("https://localhost:5006/bucket/getByPerson?personId=" + this.userId)
            .then((result) => {
                console.log(result)
                this.items = result.data
            })
            .catch((result) => {

            })
        })
    },
    methods: {
        remove(id, index) {
            axios.delete("https://localhost:5006/bucket/delete?id=" + id)
            .then((result) => {
                this.items.splice(index, 1)
            })
        },
        order() {
            axios.post("https://localhost:5006/orderhistory/create", {
                orderInfo: {
                    personId: this.userId
                }
            })
            .then((result) => {
                console.log(result)

                let mod = ""

                this.items.forEach((current, index, array) => {
                    mod += "&itemsIds=" + current.id
                })
                
                axios.post("https://localhost:5006/orderitem/create?orderId=" + result.data.id + "&infoId=" + result.data.orderInfoId + mod)
                    .then((results) => {
                        console.log(results)
                        this.items.splice(0, this.items.length)
                    })
                    .catch((results) => {
                        console.log(results)
                    })
                
            })
            .catch((result) => {
                console.log(result)
            })
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