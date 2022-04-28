<template>
  <div id="app">
  
    <Login @register="setReg" @showBook="setBookmark" @showBucket="setBucket"/>

    <HeadComponent @categoryChange="changeCat">
    </HeadComponent>

    <center>
      <div v-if="categoryId > 0 && itemId <= 0">
        <ShowCategoryItem 
            :categoryId="categoryId" 
            :items="items" 
            :model="categoryId" 
            @listChange="updateList"
            @selectItem="selectItem">
        </ShowCategoryItem>
      </div>
      <div class="item" v-else-if="itemId >= 1">
        {{ itemId }}
        <ShowItem :itemId="itemId">
        </ShowItem>
      </div>
      <div v-else-if="registration">
        <RegisterForm>
        </RegisterForm>
      </div>
      <div v-else-if="isBookmark">
        <Bookmark>
        </Bookmark>
      </div>
      <div v-else-if="isBucket">
        <Bucket>
        </Bucket>
      </div>
    </center>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import SomeComponent from "@/components/SomeComponent"
import HeadComponent from "@/components/HeadComponent"
import ShowCategoryItem from "@/components/ShowCategoryItem"
import ShowItem from "@/components/ShowItem"
import RegisterForm from "@/components/RegisterForm"
import AuthService from '@/components/AuthServer'
import Bookmark from '@/components/Bookmark'
import Bucket from '@/components/Bucket'
import axios from 'axios'

import Login from '@/pages/Login'

const auth = new AuthService()

export default {
  name: 'App',
  components: {
    HelloWorld,
    SomeComponent,
    HeadComponent,
    ShowCategoryItem,
    Login,
    ShowItem,
    RegisterForm,
    axios,
    Bookmark,
    Bucket,
  },
  data() {
    return {
      categoryId: -1,
      categories: [],
      items: [],
      itemId: 0,
      registration: false,
      lastPath: "",
      isBookmark: false,
      isBucket: false
    }
  },
  methods: {
    setReg() {
      this.registration = true
      this.categoryId = -1
      this.itemId = 0
      this.isBookmark = false
      this.isBucket = false
    },
    setBookmark() {
      this.isBookmark = true
      this.registation = false
      this.categoryId = -1
      this.itemId = 0
      this.isBucket = false
    },
    setBucket() {
      this.isBucket = true
      this.isBookmark = false
      this.registation = false
      this.categoryId = -1
      this.itemId = 0
    },
    changeCat(newValue, categories) {
      if (this.categories.length == 0) {
        console.log("asdasda")
        this.categories = categories
      }

      if (newValue == this.categoryId) {
        return
      }

      this.items = []
      this.categoryId = newValue
      this.itemId = 0
      this.registation = false
      this.isBookmark = false
      this.isBucket = false
    },
    selectItem(index) {
      this.itemId = index
      this.items = []
      this.categoryId = -1
      this.registation = false
      this.isBookmark = false
      this.isBucket = false
    },
    updateList(newValue) {
      this.items = newValue
    },
    findPath() {
      console.log("Created")
      console.log(window.location)
      let path = window.location.pathname

      console.log(path)

      if (path == "/") {
        return
      }
      if (path == "/register") {
        this.setReg()
        return
      }
      else if (path == "/login") {
        auth.login()
        return
      }

      let splitedPath = path.split('/')
      console.log(splitedPath)
      
      if (splitedPath.length == 2) {
        axios.get("https://localhost:5006/category/getByName?name=" + splitedPath[1])
        .then((result) => {
          // There will be 404...

          this.categoryId = result.data.id
        })
        .catch((result) => {
          console.log("err")
          console.log(result)
        })
      }

      console.log(this.categories.length)
    }
  },
  mounted() {
    console.log("query")
    console.log(this.$route.query)
    this.lastPath = window.location.pathname
    this.findPath()
    this.$route.query.id = 3
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

li {
  list-style: none;
  margin: 1rem;
  padding: 1rem;
}
</style>
