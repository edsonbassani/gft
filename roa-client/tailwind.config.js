/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  corePlugins: {
    preflight: false
  },
  mode: 'jit',
  content: ['./src/**/*.{html,ts}'],
  theme: {
    fontFamily: {
      'sans': ["HelveticaNeue", "Helvetica", "Arial", 'ui-sans-serif'],
    },
    extend: {
      padding: {
        '1/2': '50%',
        full: '100%',
        half: '50%',
      },
    }
  },
  plugins: [],
}
