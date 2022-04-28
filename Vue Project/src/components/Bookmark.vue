<template>
    <div class="container">
        <div v-for="(item, index) in items" class="item">
            <img :src="'images/' + item.item.imgSrc" width="256" height="256">
            <li>{{ item.item.name }}</li>
            <button v-on:click="remove(item.id, index)" class="btn">Delete</button>
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
            isLoggedIn: false
        }
    },
    mounted() {
        auth.getUser()
        .then((result) => {
            this.isLoggedIn = true
            this.userId = result.profile.sub
            
            axios.get("https://localhost:5006/bookmark/getByPerson?personId=" + this.userId)
            .then((result) => {
                this.items = result.data
            })
            .catch((result) => {

            })
        })
    },
    methods: {
        remove(id, index) {
            axios.delete("https://localhost:5006/bookmark/delete?id=" + id)
            .then((result) => {
                this.items.splice(index, 1)
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
        flex-wrap: wrap;
    }

    .item {
        margin: 20px;
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