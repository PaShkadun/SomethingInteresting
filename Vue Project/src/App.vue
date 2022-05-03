<template>
  <div id="app">
  
    <Login @register="register" @showBook="setBookmark" @showBucket="setBucket"/>

    <HeadComponent @categoryChange="changeCat">
    </HeadComponent>

    <center>
      <div v-if="mainPage" class="categories-container">
        <div v-for="(cat, index) in categories" @click="changeCat(index, categories)">
          <p>{{ cat.name }}</p>
          <img :src="'images/' + cat.imgSrc" @error="$event.target.src = 'images/img.png'" :width="256" :height="256">
        </div>
      </div>
      <div v-else-if="categoryId >= 0 && itemId <= 0">
        <ShowCategoryItem 
            :categoryId="categoryId" 
            :items="items" 
            :model="categoryId" 
            @listChange="updateList"
            @selectItem="selectItem">
        </ShowCategoryItem>
      </div>
      <div class="item" v-else-if="itemId >= 0">
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
      <div v-else-if="isProfile">
        <Profile>
        </Profile>
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
import Profile from '@/components/Profile'
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
    Profile,
  },
  data() {
    return {
      categoryId: -1,
      categories: [],
      items: [],
      itemId: -1,
      registration: false,
      lastPath: "",
      isBookmark: false,
      isBucket: false,
      mainPage: false,
      isProfile: false
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
      this.itemId = -1
      this.isBookmark = false
      this.isBucket = false
    },
    setBookmark() {
      this.isBookmark = true
      this.registation = false
      this.categoryId = -1
      this.itemId = -1
      this.isBucket = false
    },
    setBucket() {
      this.isBucket = true
      this.isBookmark = false
      this.registation = false
      this.categoryId = -1
      this.itemId = -1
    },
    setProfile() {
      this.isBookmark = false
      this.isBucket = false
      this.registation = false
      this.categoryId = -1
      this.itemId = -1
      this.isProfile = true
    },
    changeCat(newValue, categories) {
      if (this.categories.length == 0) {
        this.categories = categories
      }

      if (newValue == -1 || this.categories[newValue] == null) {
        return
      }

      window.location.pathname = '/' + this.categories[newValue].name.toLowerCase()

      this.items = []
      this.categoryId = this.categories[newValue]
      this.itemId = -1
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
      let path = window.location.pathname.toLowerCase()

      console.log(path)

      if (path == "/") {
        this.mainPage = true
        return
      }
      
      this.mainPage = false

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
        return
      }
      else if (path == "/profile") {
        this.setProfile()
        return
      }

      path = path.replace('%20', ' ')
      let splitedPath = path.split('/')
      console.log(splitedPath)
      
      if (splitedPath.length == 2) {
        axios.get("https://localhost:5006/category/getByName?name=" + splitedPath[1])
        .then((result) => {
          if (result.data == "") {
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

.categories-container {
    display: flex;
    flex-wrap: wrap;
    margin-top: 50px;
}

.categories-container div {
    margin: 20px;
}

.categories-container div:hover {
    cursor: pointer;
    background: #CAEBDA;
}

li {
  list-style: none;
  margin: 1rem;
  padding: 1rem;
}
</style>
