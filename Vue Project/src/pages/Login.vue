<template>
    <div class="home">
        <div class="home">
            <p v-if="isLoggedIn" class="username"><a href="http://localhost:8080/profile">User: {{ username }}</a></p>
            <button class="btn" @click="login" v-if="!isLoggedIn">Login</button>
            <button class="btn" @click="register" v-if="!isLoggedIn">Register</button>
            <button class="btn" @click="showBucket" v-if="isLoggedIn"><img width="32" height="32" src="http://localhost:8080/images/bucket.png"></button>
            <button class="btn" @click="showBookmark" v-if="isLoggedIn">Bookmark</button>
            <button class="btn" @click="logout" v-if="isLoggedIn">Logout</button>
        </div>
    </div>
</template>
<script>
    import Vue from 'vue'
    import Component from 'vue-class-component'
    import AuthService from '@/components/AuthServer'
 
    import axios from 'axios'
 
    const auth = new AuthService()
 
    Component({
        components: {
        },
    })

    @Component
    export default class HelloWorld extends Vue {
        currentUser = ''
        accessTokenExpired = false
        isLoggedIn = false
 
        dataEventRecordsItems = []
 
        get username() {
            return this.currentUser
        }
 
        login() {
            auth.login()
        }

        register() {
            this.$emit("register")
        }

        showBucket() {
            window.location.pathname = '/bucket'
            this.$emit("showBucket")
        }

        showBookmark() {
            window.location.pathname = '/bookmark'
            this.$emit("showBook")
        }
 
        logout() {
            auth.logout()
        }
 
        mounted() {
            auth.getUser().then((user) => {
                console.log("user: ")
                console.log(user)
                console.log(auth)
                this.currentUser = user.profile.name
                this.accessTokenExpired = user.expired
 
                this.isLoggedIn = (user !== null && !user.expired)
            })
        }
 
        getProtectedApiData() {
            console.log("go")
            const authorizationHeader = 'Authorization'
            auth.getAccessToken().then((userToken) => {
                axios.defaults.headers.common[authorizationHeader] = `Bearer ${userToken}`
 
                axios.get('https://localhost:5002/user/')
                    .then((response) => {
                        this.dataEventRecordsItems = response.data
                    })
                    .catch((error) => {
                        this.dataEventRecordsItems = error
                    })
            })
        }
    }
</script>
<style>
    .username {
        display: contents;
        color: blue;
    }

    .username:hover {
        cursor: pointer;
    }

    .home {
        text-align-last: right;
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