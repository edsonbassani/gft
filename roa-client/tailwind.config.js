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
      colors: {
        'em-blue': '#0c69b0',
        'em-curious-blue': '#3190d9',
        'em-deep-blue': '#111122',
        'em-red': '#d82424',
        'em-darkred': '#ad1723',
        'em-lightgray': '#f5f5f5',
        'em-mediumgray': '#545459',
        'em-darkgray': '#212131',
        'em-burgundy': '#ad1723',
        'em-vermillion': '#d93900',
        'em-orange': '#ed8b00',
        'em-amber': '#f2ac33',
        'em-yellow': '#ffd700',
        'em-lime': '#b4d405',
        'em-green': '#00af53',
        'em-turquoise': '#00aca8',
        'em-seablue': '#005f7f',
        'em-cyan': '#00a3e0',
        'em-indigo': '#002f6c',
        'em-violet': '#3a397b',
        'em-purple': '#7a4183',
        'em-cerise': '#a71065',
        'em-plum': '#890c58',
        'em-ruby': '#b10040',
      }
    }
  },
  plugins: [],
}
