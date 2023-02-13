const initState = () => ({
  product: {},
  products: [],
})

export const state = initState

export const mutations = {
  setProduct(state, {product}) {
    state.product = product
  },
  setProducts(state, {products}) {
    state.products = products
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchProduct({ commit }, {productId}) {
    const product = await this.$axios.$get('http://localhost:5000/api/products/' + productId)
    commit("setProduct", {product})
  },
  async fetchProducts({ commit }) {
    const products = await this.$axios.$get('http://localhost:5000/api/products')
    commit("setProducts", {products})
  },
  async createProduct({ commit, dispatch }, {product}) {
    await this.$axios.$post('http://localhost:5000/api/products', product)
    dispatch("fetchProducts")
  }
}
