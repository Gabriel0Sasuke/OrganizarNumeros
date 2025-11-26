using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrganizarNumeros
{
    public partial class Dificil : Form
    {
        int contador = 0;
        private readonly int[,] board = new int[6, 6]; // 0 representa espaço vazio
        private Button[,] buttons;
        private readonly Random rng = new();

        public Dificil()
        {
            InitializeComponent();
            // Mapear os botões na grade (6x6)
            buttons = new Button[6, 6]
            {
                { Gamex1y1, Btnx2y1, Btnx3y1, Btnx4y1, Btnx5y1, Btnx6y1 },
                { Btnx1y2, Btnx2y2, Btnx3y2, Btnx4y2, Btnx5y2, Btnx6y2 },
                { Btnx1y3, Btnx2y3, Btnx3y3, Btnx4y3, Btnx5y3, Btnx6y3 },
                { Btnx1y4, Btnx2y4, Btnx3y4, Btnx4y4, Btnx5y4, Btnx6y4 },
                { Btnx1y5, Btnx2y5, Btnx3y5, Btnx4y5, Btnx5y5, Btnx6y5 },
                { Btnx1y6, Btnx2y6, Btnx3y6, Btnx4y6, Btnx5y6, Btnx6y6 }
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
        private void Btnx5y1_Click(object sender, EventArgs e) { }
        private void Btnx6y1_Click(object sender, EventArgs e) { }
        private void Btnx1y2_Click(object sender, EventArgs e) { }
        private void Btnx2y2_Click(object sender, EventArgs e) { }
        private void Btnx3y2_Click(object sender, EventArgs e) { }
        private void Btnx4y2_Click(object sender, EventArgs e) { }
        private void Btnx5y2_Click(object sender, EventArgs e) { }
        private void Btnx6y2_Click(object sender, EventArgs e) { }
        private void Btnx1y3_Click(object sender, EventArgs e) { }
        private void Btnx2y3_Click(object sender, EventArgs e) { }
        private void Btnx3y3_Click(object sender, EventArgs e) { }
        private void Btnx4y3_Click(object sender, EventArgs e) { }
        private void Btnx5y3_Click(object sender, EventArgs e) { }
        private void Btnx6y3_Click(object sender, EventArgs e) { }
        private void Btnx1y4_Click(object sender, EventArgs e) { }
        private void Btnx2y4_Click(object sender, EventArgs e) { }
        private void Btnx3y4_Click(object sender, EventArgs e) { }
        private void Btnx4y4_Click(object sender, EventArgs e) { }
        private void Btnx5y4_Click(object sender, EventArgs e) { }
        private void Btnx6y4_Click(object sender, EventArgs e) { }
        private void Btnx1y5_Click(object sender, EventArgs e) { }
        private void Btnx2y5_Click(object sender, EventArgs e) { }
        private void Btnx3y5_Click(object sender, EventArgs e) { }
        private void Btnx4y5_Click(object sender, EventArgs e) { }
        private void Btnx5y5_Click(object sender, EventArgs e) { }
        private void Btnx6y5_Click(object sender, EventArgs e) { }
        private void Btnx1y6_Click(object sender, EventArgs e) { }
        private void Btnx2y6_Click(object sender, EventArgs e) { }
        private void Btnx3y6_Click(object sender, EventArgs e) { }
        private void Btnx4y6_Click(object sender, EventArgs e) { }
        private void Btnx5y6_Click(object sender, EventArgs e) { }
        private void Btnx6y6_Click(object sender, EventArgs e) { }

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
                nums = Enumerable.Range(1, 35).ToList();
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
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 6; c++)
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
            int linha = indiceVazio / 6; // 0 topo
            int linhaAPartirDeBaixo = 6 - linha; // 1 a 6
            bool linhaPar = linhaAPartirDeBaixo % 2 == 0;
            bool inversoesPar = inversoes % 2 == 0;
            // largura par (6): mesmo padrão do 4x4
            return (linhaPar && !inversoesPar) || (!linhaPar && inversoesPar);
        }

        private void AtualizarUI()
        {
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 6; c++)
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
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 6; c++)
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
                if (nr >= 0 && nr < 6 && nc >= 0 && nc < 6 && board[nr, nc] == 0)
                    return (nr, nc);
            }
            return (-1, -1);
        }

        private bool EstaResolvido()
        {
            int esperado = 1;
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 6; c++)
                {
                    if (r == 5 && c == 5)
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
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 6; c++)
                    board[r, c] = (r == 5 && c == 5) ? 0 : val++;
            AtualizarUI();
        }
    }
}
