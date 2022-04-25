<template>
    <div>
        <div v-if="categories.length == 0" :width="windowWidth" :height="windowHeight" class="test">
            <img src="images/loading.gif">
        </div>
        <div v-else class="categories">
            <li v-for="(cat, index) in categories">
                <a href="#" v-on:click="onClickCategory(index + 1)">{{ cat.name }}</a>
            </li>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            categories: [],
            categoryId: -1,
            windowHeight: window.innerHeight,
            windowWidth: window.innerWidth
        }
    },
    methods: {
        changeCat() {
            this.categoryId++
            this.$emit("categoryChange", this.categoryId, this.categories);
        },
        onClickCategory(value) {
            this.categoryId = value
            this.$emit("categoryChange", value, this.categories)
        }
    },
    created() {
        axios.get("https://localhost:5006/category/getAll")
        .then((result) => {
            console.log(result)
            this.categories = result.data
            this.$emit("categoryChange", -1, this.categories)
        })
        .catch((result) => {
            console.log(result)
        })
    }
}
</script>

<style>
    .categories {
        display: flex;
        flex-wrap: wrap;
        background: gainsboro;
    }
    .categories li {
        border: 1px solid black;
        padding: 10px 25px;
        margin: 0px;
    }
</style>