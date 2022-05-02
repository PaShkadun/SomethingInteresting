<template>
    <div style="display: flex; width: 100%;">
        <div class="img">
            <img :src="getBaseUrl() + '/images/' + item.imgSrc" @error="defaultImg" :width="512" :height="512">
        </div>
        <div class="item-info">
            <li>{{item.name}}</li>
            <li>{{item.price}}</li>
            <li>{{item.description}}</li>
            <div v-if="isLoggedIn">
                <button v-if="!addedToBucket" v-on:click="addToBucket" class="btn">Bucket</button>
                <button v-else v-on:click="addToBucket" class="btn" disabled>Bucket</button>
                <button v-if="!addedToBookmark" v-on:click="addToBookmark" class="btn">Bookmark</button>
                <button v-else v-on:click="addToBookmark" class="btn" disabled>Bookmark</button>
            </div>
            <div v-else>
                <li>To add this item to bucket/bookmark, please, <button v-on:click="login" class="btn">login</button></li>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import AuthServer from "@/components/AuthServer"

const auth = new AuthServer()

export default {
    props: [
        "itemId"
    ],
    data() {
        return {
            currentItemId: 0,
            item: [],
            isLoggedIn: false,
            userId: "",
            addedToBookmark: false,
            addedToBucket: false
        }
    },
    methods: {
        render() {
            axios.get("https://localhost:5006/item/getById?id=" + this.currentItemId)
            .then((result) => {
                console.log(result)
                this.item = result.data
            })
            .catch((result) => {
                console.log(result)
            })
        },
        login() {
            auth.login()
        },
        addToBookmark() {
            axios.post("https://localhost:5006/bookmark/create", {
                itemId: this.itemId,
                personId: this.userId
            })
            .then((result) => {
                this.addedToBookmark = true
                console.log(result)
            })
            .catch((result) => {
                console.log("error")
                console.log(result)
            })
        },
        addToBucket() {
            axios.post("https://localhost:5006/bucket/create", {
                itemId: this.itemId,
                personId: this.userId
            })
            .then((result) => {
                this.addedToBucket = true
            })
            .catch((result) => {
                console.log("error")
                console.log(result)
            })
        },
        getBaseUrl() {
            return window.location.origin
        },
        defaultImg(event) {
            event.target.src = window.location.origin + '/images/img.png'
        }
    },    
    updated() {
        console.log("up")
        if (this.currentItemId == this.itemId) {
            return;
        }

        this.currentItemId = this.itemId
        this.render()
    }, 
    mounted() {
        this.currentItemId = this.itemId
        this.render()

        console.log("auth")
        auth.getUser()
        .then((result) => { 
            if (result != null) {
                this.isLoggedIn = true
                this.userId = result.profile.sub
            }
        })
    }
}
</script>

<style>
    .item-info {
        width: 100%;
    }

    .item-info:hover {
        cursor: default;
    }

    button:hover {
        cursor: pointer;
    }

    .btn:disabled {
        background: #eaeaea;
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