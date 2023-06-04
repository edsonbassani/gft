/** @type {import('tailwindcss').Config} */
import { mountainmeadow } from './src/styles/palettes/js/mountain-meadow';
import { grayscale } from './src/styles/palettes/js/black';
import { eletricviolet } from './src/styles/palettes/js/eletric-violet';
import { richgold } from './src/styles/palettes/js/gold';
import { tamarillo } from './src/styles/palettes/js/tamarillo';
import { toryblue } from './src/styles/palettes/js/tory-blue';

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
     colors:{
        ...mountainmeadow,
        ...grayscale,
        ...eletricviolet,
        ...richgold,
        ...tamarillo,
        ...toryblue,
     },
    }
  },
  plugins: [],
}
