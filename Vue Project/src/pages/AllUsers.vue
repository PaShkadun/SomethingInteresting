<template>
    <div>
        <div v-if="dataEventRecordsItem && dataEventRecordsItem.length">
            <textarea>{{dataEventRecordsItem}}</textarea>
            <br><br>
        </div>
        <input type="text" placeholder="Input user's ID here">
        <button type="submit" @click="GetAllUsers">&times;</button>
    </div>
</template>

<script>
import axios from 'axios'
import HelloWorld from './Login'
import Component from 'vue-class-component'
import AuthService from '@/components/AuthServer'

    const auth = new AuthService()

    @Component
    export default class AllUserApi extends HelloWorld {
        dataEventRecordsItem = []

        GetAllUsers() {
            const authorizationHeader = 'Authorization'
            auth.getAccessToken().then((userToken) => {
                axios.defaults.headers.common[authorizationHeader] = `Bearer ${userToken}`
                console.log(0, userToken)
                axios.get('https://localhost:5002/user/')
                     .then((response) => {
                        this.dataEventRecordsItem = response.data
                     })
                     .catch((error) => {
                        this.dataEventRecordsItem = error
                     })
            })
        }
    }

</script>