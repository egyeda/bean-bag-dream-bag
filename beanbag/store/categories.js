const initState = () => ({
  categories: [],
})

export const state = initState

export const mutations = {
  setCategories(state, {categories}) {
    state.categories = categories
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchCategories({ commit }) {
    const products = await this.$axios.$get('http://localhost:5000/api/categories')
    commit("setCategories", {products})
  },
  async createCategory({ commit, dispatch }, {category}) {
    await this.$axios.$post('http://localhost:5000/api/categories', category)
    dispatch("fetchCategories")
  }
}
