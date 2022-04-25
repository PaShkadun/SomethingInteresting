<template>
    <div class="home">
        <img alt="Vue logo" src="@/assets/logo.png">
        <div class="home">
            <p v-if="isLoggedIn">User: {{ username }}</p>
            <div v-else>
                <button @click="registration">Reg</button>
            </div>
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
    export default class Register extends Vue {
        isLoggedIn = false
        dataEventRecordsItems = []
        username = ''

        registration() {
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
                axios.post('https://localhost:5001/register', {
                    name: "name",
                    email: "name@a.a",
                    password: "aaaA!1"
                })
                    .then((response) => {
                        console.log("success")
                        //this.dataEventRecordsItems = response.data
                    })
                    .catch((error) => {
                        console.log("failed")
                        //this.dataEventRecordsItems = error
                    })

            //console.log(this.dataEventRecordsItems)
        }

        mounted() {
            console.log("asd")
            auth.getUser().then((user) => {
                if (user !== null) {
                    this.isLoggedIn = true
                    this.username = user.profile.name
                }
            })
        }
    }
</script>

<style>

</style>