require("@cadl-lang/eslint-config-cadl/patch/modern-module-resolution");

module.exports = {
  plugins: ["@typespec/eslint-plugin-typespec"],
  extends: ["@typespec/eslint-config-typespec", "plugin:@typespec/eslint-plugin-typespec/recommended"],
  parserOptions: { tsconfigRootDir: __dirname },
};
