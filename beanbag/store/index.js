const initState = () => ({
})

export const state = initState

export const mutations = {
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async nuxtServerInit({ commit, dispatch }) {
    await dispatch("products/fetchProducts")
    await dispatch("categories/fetchCategories")
  }
}
