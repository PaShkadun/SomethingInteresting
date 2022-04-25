<template>
    <div>
        <div v-if="dataEventRecordsItems.data">
            <textarea>{{dataEventRecordsItems.data}}</textarea>
            <br><br>
        </div>
        <input type="text" v-model="inputValue" placeholder="Input user's ID here">
        <button type="submit" @click="GetUser">&times;</button>
    </div>
</template>

<script>
import axios from 'axios'
import HelloWorld from './Login'
import Component from 'vue-class-component'
import AuthService from '@/components/AuthServer'

    const auth = new AuthService()

    @Component
    export default class UserApi extends HelloWorld {
        dataEventRecordsItems = []

        GetUser() {
            const authorizationHeader = 'Authorization'
            auth.getAccessToken().then((userToken) => {
                axios.defaults.headers.common[authorizationHeader] = `Bearer ${userToken}`
                axios.get('https://localhost:5004/company/user/' + this.inputValue)
                     .then((response) => {
                        this.dataEventRecordsItems = response
                        console.log(this.dataEventRecordsItems)
                     })
                     .catch((error) => {
                        this.dataEventRecordsItems = error
                        console.log(this.dataEventRecordsItems)
                     })
            })
        }
    }

</script>