module.exports = {
    content: [
        "./**/*.html",
        "./**/*.razor",
        "./**/*.cshtml",
        "./**/*.json",
    ],
    theme: {
        extend: {
            colors: {
                'brand': {
                    DEFAULT: '#049399',
                    '50': '#A9F9FD',
                    '100': '#96F8FC',
                    '200': '#6EF6FB',
                    '300': '#46F3FA',
                    '400': '#1EF0F9',
                    '500': '#06DFE9',
                    '600': '#05B9C1',
                    '700': '#049399',
                    '800': '#035E62',
                    '900': '#012A2C'
                },
            },
        }
    },
    plugins: [
        require("@tailwindcss/typography"),
        require("@tailwindcss/forms"),
        require('@tailwindcss/line-clamp'),
        require("tailwind-scrollbar")
    ],
}