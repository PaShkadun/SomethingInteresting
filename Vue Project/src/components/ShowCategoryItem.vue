<template>
    <div>
        <div v-if="isLoading">
            <img src="http://localhost:8080/images/loading.gif" :width="256" :height="256">
        </div>
        <div>
            <select @change="onChangeSorting($event)" class="btn">
                <option disabled>Сортировать по:</option>
                <option value="name">По имени А-Я</option>
                <option value="name desc">По имени Я-А</option>
                <option value="price">Сначала дешёвые</option>
                <option value="price desc">Сначала дорогие</option>
            </select>
            <select @change="onChangeSize($event)" class="btn">
                <option disabled>Элементов на странице</option>
                <option value="5">5</option>
                <option value="10">10</option>
                <option value="25">25</option>
                <option value="50">50</option>
            </select>
        </div>
        <div class="someC">
            <div v-for="item in items">
                <div class="item">
                    <a v-on:click="selectItem(item.id)">
                        <li>{{ item.name }}</li>
                        <img :width="256" :height="256" :src="getBaseUrl() + '/images/' + item.imgSrc" @error="defaultPath">
                        <li>{{ item.price }}</li>
                    </a>
                </div>
            </div>
        </div>
        <div class="buttons">
            <div v-for="index in paginationInfo.TotalPages">
                <button v-if="index === paginationInfo.CurrentPage" class="btn" disabled>{{index}}</button>
                <button v-else class="btn" v-on:click="changePage(index)">{{index}}</button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: [
        "categoryId",
        "items"
    ],
    data() {
        return {
            currentCategoryId: 0,
            paginationInfo: [],
            sortBy: "",
            itemPerPage: 5,
            currentPage: 1,
            isLoading: false
        }
    },
    methods: {
        onChangeSorting(event) {
            this.sortBy = event.target.value
            this.render()
        },
        onChangeSize(event) {
            this.itemPerPage = event.target.value
            this.render()
        },
        render() {
            if (this.currentCategoryId <= 0) {
                return;
            }
            
            this.isLoading = true

            console.log("send request")

            axios.get("https://localhost:5006/item/getByCategory?categoryId=" + parseInt(this.currentCategoryId) + "&pageSize=" + parseInt(this.itemPerPage) + "&pageNumber=" + (this.currentPage) + "&orderBy=" + this.sortBy)
            .then((result) => {
                this.isLoading = false
                console.log("OK")
                this.$emit("listChange", result.data);
                this.paginationInfo = JSON.parse(result.headers['x-pagination'])
            })
            .catch((result) => {
                this.isLoading = false
                console.log("error")
                console.log(result)
            })
        },
        changePage(index) {
            this.currentPage = index
            this.render()
        },
        selectItem(index) {
            this.$emit("selectItem", index)
        },
        getBaseUrl() {
            return window.location.origin
        },
        defaultPath(event) {
            event.target.src = this.getBaseUrl() + '/images/img.png'
        }
    },
    mounted() {
        this.currentCategoryId = this.categoryId
        this.render()
    },
    updated() {
        if (this.currentCategoryId != this.categoryId) {
            this.currentCategoryId = this.categoryId
            this.render()
        }
    }
}

</script>

<style>
    .item p {
        padding: 0;
        margin: 0;
    }

    .buttons {
        display: inline-flex;
    }

    .item a:hover {
        background: #CAEBDA;
    }

    .someC {
        width: 90%;
        display: flex;
        flex-wrap: wrap;
    }

    .someC div {
        margin: 20px 20px;
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

    .btn:disabled {
        background-color: #eaeaea;
    }
</style>