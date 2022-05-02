<template>
  <div id="app">
  
    <Login @register="register" @showBook="setBookmark" @showBucket="setBucket"/>

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
    register() {
      window.location.pathname = '/register'
      this.setReg()
    },
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
        this.categories = categories
      }

      window.location.pathname = '/' + this.categories[newValue].name.toLowerCase()

      this.items = []
      this.categoryId = this.categories[newValue]
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

      window.location.pathname += '/' + index
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
      else if (path == "/bucket") {
        this.setBucket()
        return
      }
      else if (path == "/bookmark") {
        this.setBookmark()
        return;
      }

      let splitedPath = path.split('/')
      console.log(splitedPath)
      
      if (splitedPath.length == 2) {
        axios.get("https://localhost:5006/category/getByName?name=" + splitedPath[1])
        .then((result) => {
          if (result.data == null) {
            this.categoryId = 0
            return
          }

          this.categoryId = result.data.id
        })
        .catch((result) => {
          console.log("category error")
          console.log(result)
        })
      }
      else if (splitedPath.length == 3) {
        let id = parseInt(splitedPath[2])

        if (id == NaN) {
          this.itemId = 0
          return
        }

        axios.get("https://localhost:5006/item/getById?id=" + id)
        .then((result) => {
          console.log(result)
          if (result.data.category.name.toLowerCase() != splitedPath[1]) {
            this.itemId = 0
            return
          }

          this.itemId = id
        })
        .catch((result) => {
          console.log("item error")
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
