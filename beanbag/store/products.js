const initState = () => ({
  products: [],
})

export const state = initState

export const mutations = {
  setProducts(state, {products}) {
    state.products = products
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchProducts({ commit }) {
    const products = await this.$axios.$get('http://localhost:5000/api/products')
    commit("setProducts", {products})
  },
  async createProduct({ commit, dispatch }, {product}) {
    await this.$axios.$post('http://localhost:5000/api/products', product)
    dispatch("fetchProducts")
  }
}
