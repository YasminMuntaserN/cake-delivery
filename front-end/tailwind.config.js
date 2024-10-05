/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
  theme: {
    fontFamily: {
      sans: ["RocknRoll One", "sans-serif"], 
    },
    extend: {
      colors: {
        basic:'#503908',
        peach: '#ffd3cd', 
        pink: '#e883a1',   
      },
      keyframes: {
        slideDown: {
          '0%': { top: '-100px' },
          '100%': { top: '0px' },
        },
      },
      animation: {
        slideDown: 'slideDown 0.5s ease-in-out',
      },
    }
  },
  plugins: [],
};

