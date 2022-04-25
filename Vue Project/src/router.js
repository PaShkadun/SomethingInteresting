import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/pages/Index'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            component: Index
        },
        {
            path: '/secondPage',
            component: () => import('@/pages/secondPages.vue')
        },
        {
            path: '/getUser',
            component: () => import('@/pages/User.vue')
        },
        {
            path: '/getAllUsers',
            component: () => import('@/pages/AllUsers.vue')
        },
        {
            path: '/login',
            component: () => import('@/pages/Login.vue')
        },
        {
            path: '/getShop',
            component: () => import('@/pages/GetShop.vue')
        },
        {
            path: '/register',
            component: () => import('@/pages/Register.vue')
        }
    ]
})