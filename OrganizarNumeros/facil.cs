using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrganizarNumeros
{
    public partial class Facil : Form
    {
        int contador = 0;
        private readonly int[,] board = new int[4, 4]; // 0 representa espaço vazio
        private Button[,] buttons;
        private readonly Random rng = new();

        public Facil()
        {
            InitializeComponent();
            // Mapear os botões na grade
            buttons = new Button[4, 4]
            {
                { Gamex1y1, Btnx2y1, Btnx3y1, Btnx4y1 },
                { Btnx1y2, Btnx2y2, Btnx3y2, Btnx4y2 },
                { Btnx1y3, Btnx2y3, Btnx3y3, Btnx4y3 },
                { Btnx1y4, Btnx2y4, Btnx3y4, Btnx4y4 }
            };
            // Registrar eventos genéricos
            foreach (var b in buttons)
                b.Click += Tile_Click;
            BtnNewGame.Click += BtnNewGame_Click;
            BtnRecomecar.Click += BtnRecomecar_Click;
            BtnSolucao.Click += BtnSolucao_Click;
            IniciarNovoJogo();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ContarClick()
        {
            contador++;
            LblNum.Text = contador.ToString();
        }

        private void Gamex1y1_Click(object sender, EventArgs e) { }
        private void Btnx2y1_Click(object sender, EventArgs e) { }
        private void Btnx3y1_Click(object sender, EventArgs e) { }
        private void Btnx4y1_Click(object sender, EventArgs e) { }
        private void Btnx1y2_Click(object sender, EventArgs e) { }
        private void Btnx2y2_Click(object sender, EventArgs e) { }
        private void Btnx3y2_Click(object sender, EventArgs e) { }
        private void Btnx4y2_Click(object sender, EventArgs e) { }
        private void Btnx1y3_Click(object sender, EventArgs e) { }
        private void Btnx2y3_Click(object sender, EventArgs e) { }
        private void Btnx3y3_Click(object sender, EventArgs e) { }
        private void Btnx4y3_Click(object sender, EventArgs e) { }
        private void Btnx1y4_Click(object sender, EventArgs e) { }
        private void Btnx2y4_Click(object sender, EventArgs e) { }
        private void Btnx3y4_Click(object sender, EventArgs e) { }
        private void Btnx4y4_Click(object sender, EventArgs e) { }

        // ===================== LÓGICA DO QUEBRA-CABEÇA =====================
        private void IniciarNovoJogo()
        {
            contador = 0;
            LblNum.Text = "0";
            GerarTabuleiroSolucionavel();
            AtualizarUI();
        }

        private void GerarTabuleiroSolucionavel()
        {
            List<int> nums;
            do
            {
                nums = Enumerable.Range(1, 15).ToList();
                // Embaralhar
                for (int i = nums.Count - 1; i > 0; i--)
                {
                    int j = rng.Next(i + 1);
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
                nums.Add(0); // vazio
            } while (!EhSolucionavel(nums));

            // Preencher matriz
            int k = 0;
            for (int r = 0; r < 4; r++)
                for (int c = 0; c < 4; c++)
                    board[r, c] = nums[k++];
        }

        private bool EhSolucionavel(List<int> arr)
        {
            int inversoes = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == 0) continue;
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j] == 0) continue;
                    if (arr[i] > arr[j]) inversoes++;
                }
            }
            int indiceVazio = arr.IndexOf(0);
            int linha = indiceVazio / 4; // 0 topo
            int linhaAPartirDeBaixo = 4 - linha; // 1 a 4
            // Regra para largura par (4):
            // Solucionável se (linhaAPartirDeBaixo par && inversões ímpar) || (linhaAPartirDeBaixo ímpar && inversões par)
            bool linhaPar = linhaAPartirDeBaixo % 2 == 0;
            bool inversoesPar = inversoes % 2 == 0;
            return (linhaPar && !inversoesPar) || (!linhaPar && inversoesPar);
        }

        private void AtualizarUI()
        {
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    int val = board[r, c];
                    var btn = buttons[r, c];
                    btn.Text = val == 0 ? string.Empty : val.ToString();
                    btn.Enabled = true; // pode deixar ativo; validação ocorre no clique
                }
            }
        }

        private void Tile_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            // Localizar posição do botão
            int br = -1, bc = -1;
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (buttons[r, c] == btn)
                    {
                        br = r; bc = c; break;
                    }
                }
                if (br != -1) break;
            }
            if (br == -1) return;
            // Encontrar vazio adjacente
            (int vr, int vc) = EncontrarVazioAdjacente(br, bc);
            if (vr == -1) return; // não há movimento
            // Trocar
            board[vr, vc] = board[br, bc];
            board[br, bc] = 0;
            ContarClick();
            AtualizarUI();
            if (EstaResolvido())
            {
                MessageBox.Show($"Parabéns! Resolvido em {contador} movimentos.", "Vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private (int, int) EncontrarVazioAdjacente(int r, int c)
        {
            int[,] dirs = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                int nr = r + dirs[i, 0];
                int nc = c + dirs[i, 1];
                if (nr >= 0 && nr < 4 && nc >= 0 && nc < 4 && board[nr, nc] == 0)
                    return (nr, nc);
            }
            return (-1, -1);
        }

        private bool EstaResolvido()
        {
            int esperado = 1;
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (r == 3 && c == 3)
                    {
                        if (board[r, c] != 0) return false;
                    }
                    else
                    {
                        if (board[r, c] != esperado) return false;
                        esperado++;
                    }
                }
            }
            return true;
        }

        // Botões de controle
        private void BtnNewGame_Click(object? sender, EventArgs e) => IniciarNovoJogo();
        private void BtnRecomecar_Click(object? sender, EventArgs e) => IniciarNovoJogo();
        private void BtnSolucao_Click(object? sender, EventArgs e)
        {
            contador = 0; LblNum.Text = "0";
            int val = 1;
            for (int r = 0; r < 4; r++)
                for (int c = 0; c < 4; c++)
                    board[r, c] = (r == 3 && c == 3) ? 0 : val++;
            AtualizarUI();
        }
    }
}
